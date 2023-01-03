using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class StatistictsConvert
    {
        public static DTO.PopularAttractionsDTO Convert(DAL.PopularAttractions obj)
        {
            if (obj == null)
                return null;
            return new DTO.PopularAttractionsDTO()
            {
                label = obj.label,
                y = obj.y,
            };
        }

        public static DAL.PopularAttractions Convert(DTO.PopularAttractionsDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.PopularAttractions()
            {
                label = obj.label,
                y =obj.y,
            };
        }

        public static List<DAL.PopularAttractions> Convert(List<DTO.PopularAttractionsDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.PopularAttractionsDTO> Convert(List<DAL.PopularAttractions> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
