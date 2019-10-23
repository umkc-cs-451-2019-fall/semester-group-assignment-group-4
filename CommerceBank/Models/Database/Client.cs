using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class Client
    {
        [Column("ClientID")]
        public int? ClientId { get; set; }
        [StringLength(10)]
        public string ClientType { get; set; }
        [StringLength(255)]
        public string FullName { get; set; }
        [Column("AccountID")]
        public int? AccountId { get; set; }
    }
}
