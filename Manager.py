from googleapiclient.discovery import build
from googleapiclient.errors import HttpError
from google_auth_oauthlib.flow import InstalledAppFlow

import google.oauth2.credentials
import google_auth_oauthlib.flow
import sys
import os
import json

def load_client():
    path = os.path.dirname(__file__)
    
    try:
        with open(path + "/Client.json") as file:
            data = json.load(file)
    except:
        while(1): 
            path = str(input("<< Client.json not found! Add path manually: \n>> "))
            try:
                with open(path + "/Client.json") as file:
                    data = json.load(file)
                    break
            except:
                pass
    return data

def update():
    print("<< Updating...")
    client = load_client()
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
    everything_is_fine = True
    client = load_client()
    youtube = build("youtube", "v3", developerKey=client["installed"]["api_key"])
    me = youtube.channels().list(id="UCreMZ1blP--vIV6WhI5B4Ag", part="contentDetails").execute()
    video_list = youtube.playlistItems().list(playlistId="PLank_q9AUgKUM5Mku7jS88VE8LnJQ1kxK", part="snippet", maxResults=50).execute()
    file_context = load_file("YoutubePlaylist.txt")
    online_content = load_videos(video_list["items"])
    local_file_size = len(file_context)
    remote_playlist_size = str(video_list["pageInfo"]["totalResults"])

    while 1:
        try:
            online_content_length = len(online_content)
            video_name = online_content[0]
            online_content.remove(video_name)
            file_context.remove(video_name)
        except:
            if(online_content_length != 0 and len(file_context) == 0):
                everything_is_fine = False
                print("<< There are missing entrie in the local file! \n<< Missing file entrie: {}\n".format(video_name))
                for entry in online_content:
                    print(entry)
                online_content.clear()

            try: 
                nextPage = video_list["nextPageToken"]
                video_list = youtube.playlistItems().list(playlistId="PLank_q9AUgKUM5Mku7jS88VE8LnJQ1kxK", part="snippet",pageToken=nextPage, maxResults=50).execute()
                online_content = load_videos(video_list["items"])
            except:
                if(len(file_context) == 0 and online_content_length == 0):
                    if everything_is_fine:
                        print("<< Everything is up to date!")
                        break
                    else: 
                        print("<< That*s is!")
                        break
                elif(len(file_context) == 0):
                    everything_is_fine = False
                    print("<< There are missing entries in your YouTube playlist! \n<< Missing playlist entries: \n")
                    for entry in file_context:
                        print(entry)
                else:
                    everything_is_fine = False
                    print("<< {} is missing! \n".format(video_name))

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

def main():
    option = input("<< Type \"update\" to update your YT-Playlist or \"check\" to see if every video is still up:\n>> ")
    if(option.lower() == "update"):
        update()
        sys.exit()
    elif(option.lower() == "check"):
        check()
        sys.exit()
    else:
        print("\n<< Bye!")
        sys.exit()
    
if __name__ == "__main__":
    main()