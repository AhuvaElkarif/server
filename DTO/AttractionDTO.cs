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
        public Nullable<int> TimeDuration { get; set; }
        public int FromAge { get; set; }
        public int TillAge { get; set; }
        public Nullable<bool> status { get; set; }
        public int DaysToCancel { get; set; }
        public System.DateTime date { get; set; }
        public int CategoryId { get; set; }
        public Nullable<int> ImageId { get; set; }

        public string Images { get; set; }

        public Nullable<double> CountAvgGrading { get; set; }

    }
}
