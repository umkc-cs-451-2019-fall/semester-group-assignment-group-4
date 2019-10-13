using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class Transactions
    {
        [Key]
        [Column("TransactionID")]
        public Guid TransactionId { get; set; }
        [Column("AccountID")]
        public int? AccountId { get; set; }
        [StringLength(10)]
        public string Dispute { get; set; }
        [StringLength(10)]
        public string TransactionType { get; set; }
        [StringLength(10)]
        public string TransactionAmount { get; set; }
        [StringLength(10)]
        public string TransactionDetails { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TransactionDate { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(Accounts.Transactions))]
        public virtual Accounts Account { get; set; }
    }
}
