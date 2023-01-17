using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class EventsInCalenderConvert
    {
        public static DTO.EventsInCalenderDTO Convert(DAL.EventsInCalender obj)
        {
            if (obj == null)
                return null;
            return new DTO.EventsInCalenderDTO()
            {
               title = obj.title,
               start = obj.start,
               backgroundColor = obj.backgroundColor,
               disabled = obj.backgroundColor!="red"
            };
        }

        public static DAL.EventsInCalender Convert(DTO.EventsInCalenderDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.EventsInCalender()
            {
                title = obj.title,
                start = obj.start,
                backgroundColor = obj.backgroundColor
            };
        }

        public static List<DAL.EventsInCalender> Convert(List<DTO.EventsInCalenderDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.EventsInCalenderDTO> Convert(List<DAL.EventsInCalender> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
