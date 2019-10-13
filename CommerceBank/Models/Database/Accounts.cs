using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class Accounts
    {
        public Accounts()
        {
            Transactions = new HashSet<Transactions>();
        }

        [Key]
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Column("ClientID")]
        public Guid? ClientId { get; set; }
        public int? Balance { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Accounts")]
        public virtual Client Client { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
