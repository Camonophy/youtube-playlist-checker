import sys
import os
from JsonHandler import load, write

try:
    from googleapiclient.discovery import build
    from googleapiclient.errors import HttpError
    from google_auth_oauthlib.flow import InstalledAppFlow
except:
    os.run("python -m pip install -r Resources/requirements.py")
    from googleapiclient.discovery import build
    from googleapiclient.errors import HttpError
    from google_auth_oauthlib.flow import InstalledAppFlow


def load_client_json(json_path):
    data = load(json_path)
    return data


def update(json_path, txt_path):
    processed  = 0
    client     = load_client_json(json_path)
    youtube    = build("youtube", "v3", developerKey=client["api_key"])
    video_list     = youtube.playlistItems().list(playlistId=client["playlist_ID"], part="snippet", maxResults=50).execute()

    with open(txt_path, "w", encoding="utf-8") as file:
        while 1:
            
            for video in (video_list["items"]):
                title = video["snippet"]["title"]
                if title in ["Deleted video", "Private video"]:
                    continue
                file.write(title + "\n")
                processed += 1
            
            try:
                nextPage = video_list["nextPageToken"]
                video_list = youtube.playlistItems().list(playlistId=client["playlist_ID"], part="snippet",pageToken=nextPage, maxResults=50).execute()
            
            except:
                break
        

def check(json_path, txt_path):
    client     = load_client_json(json_path)
    youtube    = build("youtube", "v3", developerKey=client["api_key"])
    video_list = youtube.playlistItems().list(playlistId=client["playlist_ID"], part="snippet", maxResults=50).execute()

    file_content   = load_file(txt_path)
    online_content = load_videos(video_list["items"])
    local_missing_content  = []
    online_missing_content = []

    while 1:
        try:
            online_content_length = len(online_content)
            file_content_length   = len(file_content)

            video_name = online_content.pop(0)
            file_content.remove(video_name)
        
        except:
            if(online_content_length != 0):
                local_missing_content.append(video_name)
            
            else:     
                try: 
                    nextPage       = video_list["nextPageToken"]
                    video_list     = youtube.playlistItems().list(playlistId=client["playlist_ID"], part="snippet",pageToken=nextPage, maxResults=50).execute()
                    online_content = load_videos(video_list["items"])
                
                except:
                    if(file_content_length + online_content_length == 0):
                        break
                    
                    else:
                        for entry in file_content:
                            online_missing_content.append(entry)
                        file_content.clear()

    return local_missing_content, online_missing_content


def load_videos(videos):
    content = []
    for video in videos:
        title = video["snippet"]["title"]
        if title not in ["Deleted video", "Private video"]:
            content.append(title + "\n")
    return content


def load_file(file_name):
    file_content = []
    try:
        with open(file_name, encoding="utf-8") as local_file:
            for line in local_file.readlines():
                file_content.append(line)
    except:
        pass
    return file_content


def main(mode, json_path, txt_path):
    if mode == "w" :
        update(json_path, txt_path)
    else:
        local_missing, online_missing = check(json_path, txt_path)
        write("Entries.json", {"local": local_missing, "online": online_missing})


if __name__ == "__main__":
    mode = str(sys.argv[1])
    json_path = str(sys.argv[2])
    txt_path = str(" ".join(sys.argv[3: len(sys.argv)]))
    main(mode, json_path, txt_path)