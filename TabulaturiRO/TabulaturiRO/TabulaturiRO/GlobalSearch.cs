using System;
using System.Collections.Generic;
using System.Text;

namespace TabulaturiRO
{
    class GlobalSearch
    {
        public int a { get; set; }
        public int t { get; set; }
        public string val { get; set; }
        public Artists artist { get; set; }
        public Track track { get; set; }
        public string Name { get; set; }

        public GlobalSearch()
        {
            a = 0;
            t = 0;
        }

        public GlobalSearch(Artists artist)
        {
            a = 1;
            t = 0;
            val = "Artist";
            this.artist = artist;
            Name = artist.Name;
            this.track = null;
        }

        public GlobalSearch(Track track)
        {
            a = 0;
            t = 1;
            val = "Track";
            this.track = track;
            Name = track.Title;
            this.artist = null;
        }

    }
}
