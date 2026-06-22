using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaliwoSpotter
{
    internal class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int ReputationPoints { get; set; }
        public DateTime CreatedAt { get; set;  } = DateTime.Now;


        public User()
        {
           
        }


    }
}
