using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class ReportConvert
    {
        public static DTO.ReportDTO Convert(DAL.report obj)
        {
            if (obj == null)
                return null;
            return new DTO.ReportDTO()
            {
                Id = obj.Id,
                UserId = obj.UserId,
                AttractionId = obj.AttractionId,
                ReportId = obj.ReportId,
                OpinionId = obj.OpinionId,
                Status = obj.Status,
                ReportName = obj.kindReport?.Name,
                UserName = obj.user?.Name,
                AttractionName = obj.attraction?.Name,
                Opinion = OpinionConvert.Convert(obj?.opinion),
                CategoryName = obj.attraction?.category.Name
            };
        }

        public static DAL.report Convert(DTO.ReportDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.report()
            {
                Id = obj.Id,
                UserId = obj.UserId,
                AttractionId = obj.AttractionId,
                ReportId = obj.ReportId,
                OpinionId = obj.OpinionId,
                Status = obj.Status,
            };
        }

        public static List<DAL.report> Convert(List<DTO.ReportDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.ReportDTO> Convert(List<DAL.report> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
