## Description

If you have a YouTube-Playlist with your favourite songs, then this tool may come in handy to you. 
After running the program for the first time to generate a __*YoutubePlaylist.txt*__ reference file, you can either check 
whether there are some changes; for instance, a video was taken down/removed or generate a new reference file.

   
## Dependencies:
 
 Simply run: 
 
 > pip3 install -r requirements.txt
 
 to gather the required packages 
 
  
## Options: 

### write:
Write a new __*YoutubePlaylist.txt*__ reference file.

### update:
Update your local reference file. 

### check:
Check your local reference file against your YouTube-Playlist to see any differences of their contents.

###### (Note that __write__ and __update__ are doing the same internally, but have been split into two commands to avoid confusion.)

    
## Run:
> python3 Manager.py
