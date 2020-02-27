using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RelateIT.Models
{
    public class Route
    {
        public Point StartLocation { get; set; }
        public Point EndLocation { get; set; }
        public List<Point> Points { get; set; }
        public string EstimatedTime { get; set; }


    }
}
