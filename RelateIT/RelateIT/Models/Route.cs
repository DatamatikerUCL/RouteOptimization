using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RelateIT.Models
{
    public class Route
    {
        public string Name { get; set; }
        public Point StartLocation { get; set; }
        public Point EndLocation { get; set; }
        public List<Point> Points { get; set; }
        public int EstimatedTime { get; set; }



    }
}
