using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderAttractionDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public int GlobalPrice { get; set; }

    }
}
