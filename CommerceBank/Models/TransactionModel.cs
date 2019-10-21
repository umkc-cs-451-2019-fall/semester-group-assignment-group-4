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
    public partial class TransactionModel
    {

        [Column("AccountID")]
        public int AccountId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }
        
        [Column(TypeName = "decimal(18, 0)")]
        public decimal AccountBalance { get; set; }
        
        [StringLength(255)]
        public string TransactionType { get; set; }
        
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TransactionAmount { get; set; }
        
        [StringLength(255)]
        public string TransactionDescription { get; set; }
        
        [StringLength(255)]
        public string TransactionLocation { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime TransactionTime { get; set; }

        public bool DisputeBool { get; set; }

        [Key]
        [Column("TransactionId")]
        public int TransactionId { get; set; }
        
    }
}
