using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class Transactions
    {
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal AccountBalance { get; set; }
        [StringLength(255)]
        public string TransactionType { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TransactionAmount { get; set; }
        [StringLength(255)]
        public string TransactionDescription { get; set; }
        [StringLength(255)]
        public string TransactionLocation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TransactionTime { get; set; }
        [Key]
        public int TransactionId { get; set; }
        public bool DisputeBool { get; set; }
    }
}
