using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class PeriodConvert
    {

        public static DTO.PeriodDTOWhitTime ConvertTime(DAL.period obj)
        {
            if (obj == null)
                return null;
            return new DTO.PeriodDTOWhitTime()
            {
                Id = obj.Id,
                FromDate = obj.FromDate,
                SeasonId = obj.SeasonId,
                TillDate = obj.TillDate,
                AttractionId = obj.AttractionId,
                IsOpen = obj.IsOpen,
                Color = obj?.IsOpen == true ? "green" : "red",
                times =  GeneralTimeConvert.Convert( obj.generalTimes.ToList())
            };
        }
        public static DAL.period ConvertTime(DTO.PeriodDTOWhitTime obj)
        {
            if (obj == null)
                return null;
            return new DAL.period()
            {
                Id = obj.Id,
                FromDate = obj.FromDate,
                SeasonId = obj.SeasonId,
                TillDate = obj.TillDate,
                AttractionId = obj.AttractionId,
                IsOpen = obj.IsOpen,
                generalTimes = GeneralTimeConvert.Convert(obj?.times.ToList())
            };
        }

        public static DTO.PeriodDTO Convert(DAL.period obj)
        {
            if (obj == null)
                return null;
            return new DTO.PeriodDTO()
            {
                Id = obj.Id,
                FromDate = obj.FromDate,
                SeasonId = obj.SeasonId,
                TillDate = obj.TillDate,
                AttractionId = obj.AttractionId,
                IsOpen = obj.IsOpen,
                Color = obj?.IsOpen==true? "green": "red"
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
                SeasonId = obj.SeasonId,
                TillDate = obj.TillDate,
                AttractionId = obj.AttractionId,
                IsOpen = obj.IsOpen,
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
