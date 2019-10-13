using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    public partial class User
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(4)]
        public string UserRights { get; set; }
        [StringLength(10)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string UserPass { get; set; }
    }
}
