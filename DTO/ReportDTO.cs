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
        public Nullable<bool> Status { get; set; }

        public string ReportName { get; set; }
        public string UserName { get; set; }
        public string AttractionName { get; set; }
        public string CategoryName { get; set; }

        public OpinionDTO Opinion { get; set; }


    }
}
