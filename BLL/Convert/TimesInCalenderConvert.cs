using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class TimesInCalenderConvert
    {
        public static DTO.TimesInCalenderDTO Convert(DAL.TimesInCalender obj)
        {
            if (obj == null)
                return null;
            return new DTO.TimesInCalenderDTO()
            {
               start = obj.start,
               end = obj.end,
            };
        }

        public static DAL.TimesInCalender Convert(DTO.TimesInCalenderDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.TimesInCalender()
            {
                start = obj.start,
                end = obj.end,
            };
        }

        public static List<DAL.TimesInCalender> Convert(List<DTO.TimesInCalenderDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.TimesInCalenderDTO> Convert(List<DAL.TimesInCalender> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}