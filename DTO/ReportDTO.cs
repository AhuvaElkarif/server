using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ReportId { get; set; }
        public Nullable<int> OpinionId { get; set; }
    }
}
