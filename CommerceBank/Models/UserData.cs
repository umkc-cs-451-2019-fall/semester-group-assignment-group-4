using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceBank.Models
{
    public partial class UserData
    {
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("HomeState")]
        public string HomeState { get; set; }

        [Column("AccountID")]
        public int AccountID { get; set; }

        [Column("Balance")]
        public decimal Balance { get; set; }
    }
}
