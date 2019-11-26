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
    public partial class ReportsAlertModel
    {
        [Column("AlertsID")]
        public int AlertsID { get; set; }

        [Column("AlertName")]
        public string AlertName { get; set; } 
    }
}
