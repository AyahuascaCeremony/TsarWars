using System;
using System.Collections.Generic;

namespace TsarWars
{
    public class Movie
    {
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string[] Producers { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Character> Characters { get; set; }
    }
}