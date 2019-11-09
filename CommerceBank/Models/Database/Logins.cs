using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class Logins
    {
        [Required]
        [StringLength(10)]
        public string UserName { get; set; }
        [StringLength(10)]
        public string Password { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }
    }
}
