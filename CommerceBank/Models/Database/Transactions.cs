using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class Transactions
    {
        [Column("AccountID")]
        public int? AccountId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransactionDate { get; set; }
        public double? AccountBalance { get; set; }
        [StringLength(255)]
        public string TransactionType { get; set; }
        public double? TransactionAmount { get; set; }
        [StringLength(255)]
        public string TransactionDescription { get; set; }
        [StringLength(255)]
        public string TransactionLocation { get; set; }
        [StringLength(2)]
        public DateTime? TransactionTime { get; set; }
        [Column(TypeName = "datetime")]
        public string DisputeBool { get; set; }
        [Key]
        [Column("TransactionID")]
        public int TransactionId { get; set; }
    }
}
