using System;
using System.Collections.Generic;

#nullable disable

namespace BC_IS413_Assignment10.Models
{
    public partial class ZtblBowlerRating
    {
        public string BowlerRating { get; set; }
        public long? BowlerLowAvg { get; set; }
        public long? BowlerHighAvg { get; set; }
    }
}
