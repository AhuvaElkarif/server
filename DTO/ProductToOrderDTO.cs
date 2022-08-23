using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductToOrderDTO
    {
        public int Id { get; set; }
        public Nullable<int> OrderAttractionId { get; set; }
        public int AttractionId { get; set; }
        public int Amount { get; set; }
        public System.TimeSpan FromHour { get; set; }
        public System.TimeSpan TillHour { get; set; }
        public bool Status { get; set; }
    }
}
