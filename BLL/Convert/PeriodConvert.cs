using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class PeriodConvert
    {
        public static DTO.PeriodDTO Convert(DAL.period obj)
        {
            if (obj == null)
                return null;
            return new DTO.PeriodDTO()
            {
                Id = obj.Id,
                FromDate = obj.FromDate,
                Season = obj.Season,
                TillDate = obj.TillDate
            };
        }

        public static DAL.period Convert(DTO.PeriodDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.period()
            {
                Id = obj.Id,
                FromDate = obj.FromDate,
                Season = obj.Season,
                TillDate = obj.TillDate
            };
        }

        public static List<DAL.period> Convert(List<DTO.PeriodDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.PeriodDTO> Convert(List<DAL.period> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
