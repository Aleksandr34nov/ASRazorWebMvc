using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public Song(int id, string title, int albumId, Album al) {
            SongId = id;
            SongTitle = title;
            AlbumId = albumId;
            Album = al;
        }

        public Song()
        {
        }
    }
}
