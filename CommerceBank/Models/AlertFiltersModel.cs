using System.ComponentModel.DataAnnotations.Schema;
namespace CommerceBank.Models
{
    public partial class AlertFiltersModel
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("AlertFilter")]
        public string AlertFilter { get; set; }
    }
}
