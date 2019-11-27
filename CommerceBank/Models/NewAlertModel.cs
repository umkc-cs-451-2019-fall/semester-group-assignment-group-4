using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceBank.Models
{
    public class NewAlertModel
    {
        public IEnumerable<int> DivID { get; set; }
        public IEnumerable<int> AlertID { get; set; }
        public IEnumerable<string> value { get; set; }
    }
}
