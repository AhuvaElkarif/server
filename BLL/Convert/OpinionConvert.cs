using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class OpinionConvert
    {
        public static DTO.OpinionDTO Convert(DAL.opinion obj)
        {
            if (obj == null)
                return null;
            return new DTO.OpinionDTO()
            {
                Id = obj.Id,
                AttractionId = obj.AttractionId,
                InsertDate = obj.InsertDate,
                OpinionText = obj.OpinionText,
                UserId = obj.UserId,
                Grading = obj.Grading,
                Status = obj.Status
            };
        }

        public static DAL.opinion Convert(DTO.OpinionDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.opinion()
            {
                Id = obj.Id,
                AttractionId = obj.AttractionId,
                InsertDate = obj.InsertDate,
                OpinionText = obj.OpinionText,
                UserId = obj.UserId,
                Status = obj.Status,
                Grading = obj.Grading
            };
        }

        public static List<DAL.opinion> Convert(List<DTO.OpinionDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.OpinionDTO> Convert(List<DAL.opinion> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
