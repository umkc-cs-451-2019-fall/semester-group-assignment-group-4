using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceBank.Models
{
    public class SelectedFiltersModel
    {
        public string? TransactionType { get; set; }
        public string? State { get; set; }
        public int? Dispute { get; set; }
        public string? TransactionDetails { get; set; }
        public decimal? GreaterThanAmount { get; set; }
        public decimal? LessThanAmount { get; set; }
        public decimal? EqualAmount { get; set; }
        public string? AfterThisDate { get; set; }
        public string? BeforeThisDate { get; set; }
        public string? ExactDate { get; set; }
    }
}
