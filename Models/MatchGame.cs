﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BC_IS413_Assignment10.Models
{
    public partial class MatchGame
    {
        public long MatchId { get; set; }
        public long GameNumber { get; set; }
        public long? WinningTeamId { get; set; }

        public virtual TourneyMatch Match { get; set; }
    }
}
