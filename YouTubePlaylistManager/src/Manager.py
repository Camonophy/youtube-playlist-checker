import sys
from sys import platform
import os
import json

try:
    from googleapiclient.discovery import build
    from googleapiclient.errors import HttpError
    from google_auth_oauthlib.flow import InstalledAppFlow
except:
    os.run("python -m pip install -r Resources/requirements.py")
    from googleapiclient.discovery import build
    from googleapiclient.errors import HttpError
    from google_auth_oauthlib.flow import InstalledAppFlow


def load_client_json():
    path = "." if(len(os.path.dirname(__file__)) == 0) else os.path.dirname(__file__)

    try:
        with open(path + "/Client.json") as file:
            data = json.load(file)
    except:
        while(1): 
            print("-----------------------------------------------------------------")
            action = str(input("<< Client.json not found! Choose one of the following options:\n" \
                "<< h ; more infos\n" \
                "<< c ; create new Client.json file\n" \
                "<< d ; new path to your Client.json file\n>> "))

            if action in ["h", "help"]:
                print("<< In order to use the features of this program,\n>> you need to have a valid API-Key from Google stored in a local Client.json file.\n" \
                    "<< Follow the official Google documentation to receive your custom key here: https://bit.ly/37wielc\n" \
                    "<< Since your key is unique and bound to your own account, DO NOT show or share it with any third party!")
            
            elif action in ["c", "create"]:
                print(">> WARNING! The following process will overwrite any existing Client.json file in path {}.".format(path))
                api_key = str(input(">> API-Key: "))
                channel_ID = str(input(">> Channel-ID (youtube.com/channel/[Channel-ID]): "))
                playlist_ID = str(input(">> Playlist-ID (youtube.com/playlist?list=[Playlist-ID]): "))
                with open(path + "/Client.json", "w") as file:
                    json.dump({"api_key": api_key, "channel_ID": channel_ID, "playlist_ID": playlist_ID}, file)
            
            elif action in ["d", "dir"]:
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
    print("<< Processing...")

    processed  = 0
    client     = load_client_json()
    youtube    = build("youtube", "v3", developerKey=client["api_key"])
    me         = youtube.channels().list(id=client["channel_ID"], part="contentDetails").execute()

    video_list     = youtube.playlistItems().list(playlistId=client["playlist_ID"], part="snippet", maxResults=50).execute()
    playlist_perc  = int(video_list["pageInfo"]["totalResults"]) // 20

    with open("YoutubePlaylist.txt", "w") as file:
        while 1:
            
            for video in (video_list["items"]):
                print(
                    "\r<< [" + 
                    "#" * (processed // playlist_perc) + " " * (20 - ((processed // playlist_perc))) + "]",
                    end=""
                )

                title = video["snippet"]["title"]
                if title in ["Deleted video", "Private video"]:
                    continue
                file.write(title + "\n")
                processed += 1
            
            try:
                nextPage = video_list["nextPageToken"]
                video_list = youtube.playlistItems().list(playlistId=client["playlist_ID"], part="snippet",pageToken=nextPage, maxResults=50).execute()
            
            except:
                print()
                print("<< File write success! Playlist length: " + str(video_list["pageInfo"]["totalResults"]))
                break
        

def check():
    print("<< Checking...")
    
    no_error   = True
    client     = load_client_json()
    processed  = 0
    missing_local  = 0
    missing_online = 0

    youtube    = build("youtube", "v3", developerKey=client["api_key"])
    me         = youtube.channels().list(id=client["channel_ID"], part="contentDetails").execute()
    video_list = youtube.playlistItems().list(playlistId=client["playlist_ID"], part="snippet", maxResults=50).execute()

    playlist_perc  = int(video_list["pageInfo"]["totalResults"]) // 20
    file_content   = load_file("YoutubePlaylist.txt")
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
                no_error = False 
                local_missing_content.append(video_name)
                missing_online += 1
            
            else:     
                try: 
                    nextPage       = video_list["nextPageToken"]
                    video_list     = youtube.playlistItems().list(playlistId=client["playlist_ID"], part="snippet",pageToken=nextPage, maxResults=50).execute()
                    online_content = load_videos(video_list["items"])
                
                except:
                    if(file_content_length + online_content_length == 0):
                        check_result_handling(no_error, local_missing_content,  online_missing_content)
                        break
                    
                    else:
                        no_error = False
                        for entry in file_content:
                            online_missing_content.append(entry)
                            missing_local += 1
                        file_content.clear()

        processed += 1
        print(
            "\r<< [" + 
            "#" * (processed // playlist_perc) + " " * (20 - ((processed // playlist_perc))) + "]" +
            "   Missing: local {}; online {}".format(missing_local, missing_online), 
            end=""
            )

    return (local_missing_content, online_missing_content)


def check_result_handling(no_error, local_missing_content, online_missing_content):
    print()
    if no_error:
        print("<< Everything is up to date!")
    else:
        print_entries = input("<< New or missing entries! Do you want to print out the content of Error.txt [y/n]?\n>> ")
        
        if print_entries.lower() in ["y", "yes", "j", "ja"]:
            
            print("<<\n<< Local missing entries:")
            for entry in local_missing_content:
                print(entry[:-1])
            
            print("\n<< Online missing entries:")
            for entry in online_missing_content:
                print(entry[:-1])
            print()


def load_videos(videos):
    content = []
    for video in videos:
        title = video["snippet"]["title"]
        if title not in ["Deleted video", "Private video"]:
            content.append(title + "\n")
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
    option = input( "--------------------------------------------------------------------------------\n" +
                "--------------------- YouTube-Playlist Manager ---------------------------------\n" +
                "--------------------------------------------------------------------------------\n" +
                "<< u ; update your playlist file (Overwrites any existing YoutubePlaylist.txt)\n" +
                "<< w ; write a new playlist file (Overwrites any existing YoutubePlaylist.txt)\n" +
                "<< c ; check the online playlist and compare it against the local reference file\n>> "
            )
    if option.lower() in ["u", "update", "w", "write", "new"]:
        update()
        sys.exit()
    elif option.lower() in ["c", "check"]:
        (local_missing, online_missing) = check()
        generate_error_file(local_missing, online_missing)
        sys.exit()
    else:
        print("\n<< Bye!")
        sys.exit()
    
if __name__ == "__main__":
    if platform == "linux":
        main()
    else:
        filename = str(" ".join(sys.argv[3: len(sys.argv)]))
        json_path = str(sys.argv[1])
        txt_path = str(sys.argv[2])
        #main()
