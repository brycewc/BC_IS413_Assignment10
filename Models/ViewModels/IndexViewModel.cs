using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BC_IS413_Assignment10.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Bowler> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string Team { get; set; }
    }
}
