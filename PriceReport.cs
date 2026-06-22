using System;
using System.Collections.Generic;
using System.Text;

namespace PaliwoSpotter
{
    internal class PriceReport
    {
        public int PriceReportID { get; set; } 

        public int StationID { get; set; }
        
        public int FuelTypeID { get; set; } 
        public int UserID { get; set; }
        public decimal Price { get; set; } 

        public DateTime ReportedAt { get; set; } = DateTime.Now; 
        public int ConfidenceScore { get; set;  }

        public Station Station { get; set; } = null!;
        public FuelType FuelType { get; set; } = null!;
        public User User { get; set; } = null!; 




        public PriceReport() { }
    }
}
