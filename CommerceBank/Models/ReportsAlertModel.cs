using System.ComponentModel.DataAnnotations.Schema;
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
