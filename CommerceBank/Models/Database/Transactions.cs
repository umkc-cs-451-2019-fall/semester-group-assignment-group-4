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
        public int? AccountBalance { get; set; }
        [StringLength(255)]
        public string TransactionType { get; set; }
        public int? TransactionAmount { get; set; }
        [StringLength(255)]
        public string TransactionDescription { get; set; }
        [StringLength(255)]
        public string TransactionLocation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransactionTime { get; set; }
        [StringLength(3)]
        public string DisputeBool { get; set; }
        [Key]
        [Column("TransactionID")]
        public int TransactionId { get; set; }
    }
}
