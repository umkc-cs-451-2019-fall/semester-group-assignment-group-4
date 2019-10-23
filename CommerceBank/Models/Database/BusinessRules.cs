using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class BusinessRules
    {
        [Key]
        [Column("RuleID")]
        public int RuleId { get; set; }
        [StringLength(10)]
        public string RuleName { get; set; }
        [StringLength(10)]
        public string RuleConstraints { get; set; }
        [Required]
        [Column("AccountID")]
        [StringLength(10)]
        public string AccountId { get; set; }
    }
}
