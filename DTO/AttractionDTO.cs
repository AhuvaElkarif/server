using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AttractionDTO
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
        public int MinParticipant { get; set; }
        public int MaxParticipant { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public int FromAge { get; set; }
        public int TillAge { get; set; }
        public Nullable<bool> Status { get; set; }
        public int DaysToCancel { get; set; }
        public System.DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public Nullable<int> TimeDuration { get; set; }
        public Nullable<int> AreaId { get; set; }
        public string Phone { get; set; }
        public Nullable<double> lat { get; set; }
        public Nullable<double> lng { get; set; }

        public string CategoryName { get; set; }

        public Nullable<int> ImageId { get; set; }

        public string Images { get; set; }

        public int?[] Seasons { get; set; }

        public Nullable<double> CountAvgGrading { get; set; }

    }
}
