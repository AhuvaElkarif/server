using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OpinionDTO
    {
        public int Id { get; set; }
        public string OpinionText { get; set; }
        public double Grading { get; set; }
        public int AttractionId { get; set; }
        public int UserId { get; set; }
        public System.DateTime InsertDate { get; set; }
    }
}
