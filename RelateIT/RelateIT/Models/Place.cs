using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace RelateIT.Models
{
    class Place
    {
        public string PlaceName { get; set; }
        public string Address { get; set; }
        public Position Position { get; set; }
    }
}
