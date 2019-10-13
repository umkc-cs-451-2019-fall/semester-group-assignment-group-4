using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class Logins
    {
        [Key]
        [StringLength(10)]
        public string UserName { get; set; }
        [StringLength(10)]
        public string Password { get; set; }
        [Column("ClientID")]
        public Guid? ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Logins")]
        public virtual Client Client { get; set; }
    }
}
