using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WishDTO
    {
        public int Id { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<int> UserId { get; set; }
        
    }
}
