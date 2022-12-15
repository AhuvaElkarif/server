using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PeriodDTO
    {
        public int Id { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime TillDate { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<bool> IsOpen { get; set; }
        public Nullable<int> SeasonId { get; set; }
    }
}
