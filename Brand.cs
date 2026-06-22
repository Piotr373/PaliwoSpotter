using System;
using System.Collections.Generic;
using System.Text;

namespace PaliwoSpotter
{
    internal class Brand
    {
        public  int BrandID { get; set; }
        public string Name { get; set; } = null!;

        public List<Station> Stations { get; set; } = new List<Station>();
        public Brand()
        {
        }

    }
}
