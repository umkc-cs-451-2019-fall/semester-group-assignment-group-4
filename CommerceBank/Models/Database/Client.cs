using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class Client
    {
        public Client()
        {
            Accounts = new HashSet<Accounts>();
            Logins = new HashSet<Logins>();
        }

        [Key]
        [Column("ClientID")]
        public Guid ClientId { get; set; }
        [StringLength(25)]
        public string FirstName { get; set; }
        [StringLength(25)]
        public string LastName { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<Accounts> Accounts { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Logins> Logins { get; set; }
    }
}
