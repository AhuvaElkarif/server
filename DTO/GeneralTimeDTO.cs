using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralTimeDTO
    {
        public int Id { get; set; }
        public Nullable<int> PeriodId { get; set; }
        public int DayInWeek { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }

        public PeriodDTO Period { get; set; }
        public bool IsOpen { get; set; }

    }
}
