using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class GeneralTimeConvert
    {
        public static DTO.GeneralTimeDTO Convert(DAL.generalTime obj)
        {
            if (obj == null)
                return null;
            return new DTO.GeneralTimeDTO()
            {
                Id = obj.Id,
                DayInWeek = obj.DayInWeek,
                EndTime = obj.EndTime,
                StartTime = obj.StartTime,
                PeriodId = obj.PeriodId,
                AttractionId = obj.AttractionId
            };
        }

        public static DAL.generalTime Convert(DTO.GeneralTimeDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.generalTime()
            {
                Id = obj.Id,
                DayInWeek = obj.DayInWeek,
                EndTime = obj.EndTime,
                StartTime = obj.StartTime,
                PeriodId = obj.PeriodId,
                AttractionId = obj.AttractionId
            };
        }

        public static List<DAL.generalTime> Convert(List<DTO.GeneralTimeDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.GeneralTimeDTO> Convert(List<DAL.generalTime> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
