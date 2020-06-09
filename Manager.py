from googleapiclient.discovery import build
from googleapiclient.errors import HttpError
from google_auth_oauthlib.flow import InstalledAppFlow

import google.oauth2.credentials
import google_auth_oauthlib.flow
import sys
import os
import json

def load_json(filename):
    path = os.path.dirname(__file__)    
    try:
        with open(path + filename + ".json") as file:
            data = json.load(file)
    except:
        while(1): 
            path = str(input("<< {} not found! Add path manually: \n>> ".format(filename + ".json")))                   #Missing option to create a new one
            try:
                with open(path + filename + ".json") as file:
                    data = json.load(file)
                    break
            except:
                pass
    return data

def write_error_json(local_missing, online_missing):
    data = {"local": local_missing, "online": online_missing}
    with open("Error.json", "w") as file:
        json.dump(data, file)

def write_error_txt(local_missing, online_missing):
    with open("Error.txt", "w") as file:
        file.writelines("Local:")
        file.writelines(local_missing)
        file.writelines("Online:")
        file.writelines(online_missing)

def update():
    print("<< Updating...")
    client = load_json("/Client")
    youtube = build("youtube", "v3", developerKey=client["installed"]["api_key"])
    me = youtube.channels().list(id="UCreMZ1blP--vIV6WhI5B4Ag", part="contentDetails").execute()
    video_list = youtube.playlistItems().list(playlistId="PLank_q9AUgKUM5Mku7jS88VE8LnJQ1kxK", part="snippet", maxResults=50).execute()

    with open("YoutubePlaylist.txt", "w") as file:
        while 1:
            for video in (video_list["items"]):
                file.write(video["snippet"]["title"] + "\n")
            try:
                nextPage = video_list["nextPageToken"]
                video_list = youtube.playlistItems().list(playlistId="PLank_q9AUgKUM5Mku7jS88VE8LnJQ1kxK", part="snippet",pageToken=nextPage, maxResults=50).execute()
            except:
                print("<< File write success! Playlist length: " + str(video_list["pageInfo"]["totalResults"]))
                break
        
def check():
    print("<< Checking...")
    no_error = True
    client = load_json("/Client")
    youtube = build("youtube", "v3", developerKey=client["installed"]["api_key"])
    me = youtube.channels().list(id="UCreMZ1blP--vIV6WhI5B4Ag", part="contentDetails").execute()
    video_list = youtube.playlistItems().list(playlistId="PLank_q9AUgKUM5Mku7jS88VE8LnJQ1kxK", part="snippet", maxResults=50).execute()
    file_context = load_file("YoutubePlaylist.txt")
    online_content = load_videos(video_list["items"])
    local_missing_content = []
    online_missing_content = []

    while 1:
        try:
            online_content_length = len(online_content)
            video_name = online_content[0]
            online_content.remove(video_name)
            file_context.remove(video_name)
        except:
            if(online_content_length != 0 and len(file_context) == 0):
                no_error = False
                for entry in online_content:
                    local_missing_content.append(entry)
                online_content.clear()

            try: 
                nextPage = video_list["nextPageToken"]
                video_list = youtube.playlistItems().list(playlistId="PLank_q9AUgKUM5Mku7jS88VE8LnJQ1kxK", part="snippet",pageToken=nextPage, maxResults=50).execute()
                online_content = load_videos(video_list["items"])
            except:
                if(len(file_context) == 0 and online_content_length == 0):
                    if no_error:
                        print("<< Everything is up to date!")
                        break
                    else: 
                        print("<< There are some new or missing entries! Check the generated Error.txt file for more info.")
                        break
                else:
                    no_error = False
                    for entry in file_context:
                        online_missing_content.append(entry)
                    file_context.clear()

    return (local_missing_content, online_missing_content)

def load_videos(videos):
    content = []
    for video in videos:
        content.append(video["snippet"]["title"] + "\n")
    return content

def load_file(file_name):
    file_context = []
    with open(file_name) as local_file:
        for line in local_file.readlines():
            file_context.append(line)
    return file_context

def generate_error_file(local_missing_new, online_missing_new):
    try:
        error_json = load_file("Error")
        local_missing_old = error_json[1]                               #Placeholder
        online_missing_old = error_json[2]                              #Placeholder

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

    except:
        write_error_json(local_missing_new, online_missing_new)

def main():
    option = input("<< Type \"update\" to update your YT-Playlist or \"check\" to see if every video is still up:\n>> ")
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
