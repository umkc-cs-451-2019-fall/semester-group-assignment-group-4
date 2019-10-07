using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceBank.Models
{
    public class TransactionModel
    {
        public int id { get; set; }
        public int account { get; set; }
        public double amount { get; set; }
        public string date { get; set; }
        public string details { get; set; }
    }
}
