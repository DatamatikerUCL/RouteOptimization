using System;
using System.Collections.Generic;
using System.Text;

namespace RelateIT.Models
{
    public class CoronaCases
    {
        public List<string> Dates { get; set; }
        public List<string> ConfirmedCases { get; set; }
        public List<string> Increased { get; set; }
        public List<string> Deaths { get; set; }

    }
}
