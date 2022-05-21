import sys
import json

def load(path):
    data = 0
    try:
        with open(path, encoding="utf-8") as file:
            data = json.load(file)
    except:
        pass
    return data

def write(path, content):
    with open(path, "w", encoding="utf-8") as file:
        json.dump(content, file)

if __name__ == "__main__":
    api_key     = str(sys.argv[1])
    channel_id  = str(sys.argv[2])
    playlist_id = str(sys.argv[3])
    path = str(" ".join(sys.argv[4: len(sys.argv)]))
    write(path + "\\Client.json", {"api_key": api_key, "channel_ID": channel_id, "playlist_ID": playlist_id})