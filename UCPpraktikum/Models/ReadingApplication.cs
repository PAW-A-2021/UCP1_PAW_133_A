using System;
using System.Collections.Generic;

namespace UCPpraktikum.Models
{
    public partial class ReadingApplication
    {
        public int IdBook { get; set; }
        public string AdventureGenre { get; set; }
        public string ActionGenre { get; set; }
        public string FantasyGenre { get; set; }

        public Account IdBookNavigation { get; set; }
    }
}
