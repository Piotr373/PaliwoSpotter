using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using NetTopologySuite.Geometries;
namespace PaliwoSpotter
{
    internal class Station
    {
        public int StationID { get; set; }
        public string Adress { get; set; } = null!;
        public string City { get; set; } = null!;
        public int BrandID { get; set; }

        public Brand Brand { get; set; } = null!;
        public NetTopologySuite.Geometries.Point Location { get; set; } = null!;
       

        public Station() 
        {
        }
    }
}
