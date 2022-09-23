using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class KindReportConvert
    {
        public static DTO.KindReportDTO Convert(DAL.kindReport obj)
        {
            if (obj == null)
                return null;
            return new DTO.KindReportDTO()
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

        public static DAL.kindReport Convert(DTO.KindReportDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.kindReport()
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

        public static List<DAL.kindReport> Convert(List<DTO.KindReportDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.KindReportDTO> Convert(List<DAL.kindReport> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
