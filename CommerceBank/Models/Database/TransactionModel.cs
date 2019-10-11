using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceBank.Models
{
    public class TransactionModel
    {
        public int id { get; set; } // Should probably change to string since we don't do math on it - KH
        public string account { get; set; } // Changed to string because sample data has a long and an int - KH
        public string amount { get; set; }
        public string date { get; set; }
        public string details { get; set; }

        public int action { get; set; }
    }
}
