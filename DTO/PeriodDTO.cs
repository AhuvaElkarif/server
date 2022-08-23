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
        public string Season { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime TillDate { get; set; }
    }
}
