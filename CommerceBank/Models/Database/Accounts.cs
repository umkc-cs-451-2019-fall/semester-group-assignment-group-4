using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class Accounts
    {
        [Key]
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Column("ClientID")]
        [StringLength(255)]
        public string ClientId { get; set; }
        public int? Balance { get; set; }
    }
}
