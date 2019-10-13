using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models.Database
{
    [Table("TEST_TABLE")]
    public partial class TestTable
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("AGE")]
        public int? Age { get; set; }
    }
}
