from googleapiclient.discovery import build
from googleapiclient.errors import HttpError
from google_auth_oauthlib.flow import InstalledAppFlow

import google.oauth2.credentials
import google_auth_oauthlib.flow
import sys
import os
import json


def load_client_json():
    path = "." if(len(os.path.dirname(__file__)) == 0) else os.path.dirname(__file__)

    try:
        with open(path + "/Client.json") as file:
            data = json.load(file)
    except:
        while(1): 
            print("-----------------------------------------------------------------")
            action = str(input("<< Client.json not found! Choose one of the following options:\n" \
                "<< \"help\" for more infos\n" \
                "<< \"create\" to create a new Client.json file\n" \
                "<< \"dir\" to set a new path to your Client.json file\n>> "))

            if(action == "help"):
                print("<< In order to use the features of this program,\n>> you need to have a valid API-Key from Google stored in a local Client.json file.\n" \
                    "<< Follow the official Google documentation to receive your custom key: https://bit.ly/37wielc\n" \
                    "<< Since your key is unique and bound to your own account only, DO NOT show or share it with any third party!")
            
            elif(action == "create"):
                print(">> WARNING! The following process will overwrite any existing Client.json file in path {}.".format(path))
                api_key = str(input(">> API-Key: "))
                channel_ID = str(input(">> Channel-ID (youtube.com/channel/[Channel-ID]): "))
                playlist_ID = str(input(">> Playlist-ID (youtube.com/playlist?list=[Playlist-ID]): "))
                with open(path + "Client.json", "w") as file:
                    json.dump({"installed": {"api_key": api_key, "channel_ID": channel_ID, "playlist_ID": playlist_ID}}, file)
            
            elif(action == "dir"):
                path = str(input(">> Path: "))
                try:
                    with open(path + "/Client.json") as file:
                        data = json.load(file)
                        break
                except:
                    pass
            
            else:
                sys.exit()

    return data

def update():
    print("<< Updating...")
    client = load_client_json()
    youtube = build("youtube", "v3", developerKey=client["installed"]["api_key"])
    me = youtube.channels().list(id=client["installed"]["channel_ID"], part="contentDetails").execute()
    video_list = youtube.playlistItems().list(playlistId=client["installed"]["playlist_ID"], part="snippet", maxResults=50).execute()

    with open("YoutubePlaylist.txt", "w") as file:
        while 1:
            for video in (video_list["items"]):
                file.write(video["snippet"]["title"] + "\n")
            try:
                nextPage = video_list["nextPageToken"]
                video_list = youtube.playlistItems().list(playlistId=client["installed"]["playlist_ID"], part="snippet",pageToken=nextPage, maxResults=50).execute()
            except:
                print("<< File write success! Playlist length: " + str(video_list["pageInfo"]["totalResults"]))
                break
        
def check():
    print("<< Checking...")
    no_error = True
    client = load_client_json()
    youtube = build("youtube", "v3", developerKey=client["installed"]["api_key"])
    me = youtube.channels().list(id=client["installed"]["channel_ID"], part="contentDetails").execute()
    video_list = youtube.playlistItems().list(playlistId="PLank_q9AUgKUM5Mku7jS88VE8LnJQ1kxK", part="snippet", maxResults=50).execute()
    file_content = load_file("YoutubePlaylist.txt")
    online_content = load_videos(video_list["items"])
    local_missing_content = []
    online_missing_content = []

    while 1:
        try:
            online_content_length = len(online_content)
            file_content_length = len(file_content)
            video_name = online_content[0]
            online_content.remove(video_name)
            file_content.remove(video_name)
        except:
            if(online_content_length != 0):
                no_error = False
                local_missing_content.append(video_name)
                print("<< {} is missing in your local playlist file.".format(video_name))
            else: 
                try: 
                    nextPage = video_list["nextPageToken"]
                    video_list = youtube.playlistItems().list(playlistId=client["installed"]["playlist_ID"], part="snippet",pageToken=nextPage, maxResults=50).execute()
                    online_content = load_videos(video_list["items"])
                except:
                    if(file_content_length + online_content_length == 0):
                        check_result_handling(no_error)
                        break
                    else:
                        no_error = False
                        for entry in file_content:
                            online_missing_content.append(entry)
                            print("<< {} not found in your Youtube playlist.".format(entry))
                        file_content.clear()

    return (local_missing_content, online_missing_content)

def check_result_handling(no_error):
    if no_error:
        print("<< Everything is up to date!")
    else:
        print_entries = input("<< New or missing entries! Do you want to print out the content of Error.txt [y/n]?")
        if print_entries.lower() == "y":
            entries = load_file("Error.txt")
            for entry in entries:
                print(entry)

def load_videos(videos):
    content = []
    for video in videos:
        content.append(video["snippet"]["title"] + "\n")
    return content

def load_file(file_name):
    file_content = []
    with open(file_name) as local_file:
        for line in local_file.readlines():
            file_content.append(line)
    return file_content

def load_error_json():
    path = os.path.dirname(__file__)    
    with open(path + "/Client.json") as file:
        data = json.load(file)

def write_error_json(local_missing, online_missing):
    data = {"local": local_missing, "online": online_missing}
    with open("Error.json", "w") as file:
        json.dump(data, file)

def write_error_txt(local_missing, online_missing):
    with open("Error.txt", "w") as file:
        file.writelines("Local:\n")
        file.writelines(local_missing)
        file.writelines("\n")
        file.writelines("Online:\n")
        file.writelines(online_missing)

def generate_error_file(local_missing_new, online_missing_new):
    try:
        error_json = load_error_json()         
        local_missing_old = error_json["local"]
        online_missing_old = error_json["online"]

        for entry in local_missing_old:
            try:
                local_missing_new.remove(entry)
            except:
                local_missing_old.remove(entry)
        local_missing_old += local_missing_new
        
        for entry in online_missing_old:
            try:
                online_missing_new.remove(entry)
            except:
                online_missing_old.remove(entry)
        online_missing_old += online_missing_new

        write_error_json(local_missing_old, online_missing_old)
        write_error_txt(local_missing_old, online_missing_old)

    except:
        write_error_json(local_missing_new, online_missing_new)
        write_error_txt(local_missing_new, online_missing_new)

def main():
    option = input("<< Type in \"update\" to update your YT-Playlist or use \"check\" to see whether any changes happened since your last update:\n>> ")
    if(option.lower() == "update"):
        update()
        sys.exit()
    elif(option.lower() == "check"):
        (local_missing, online_missing) = check()
        generate_error_file(local_missing, online_missing)
        sys.exit()
    else:
        print("\n<< Bye!")
        sys.exit()
    
if __name__ == "__main__":
    main()
