using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class WishConvert
    {
        public static DTO.WishDTO Convert(DAL.wish obj)
        {
            if (obj == null)
                return null;
            return new DTO.WishDTO()
            {
                Id = obj.Id,
                AttractionId = obj.AttractionId,
                UserId = obj.UserId
            };
        }

        public static DAL.wish Convert(DTO.WishDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.wish()
            {
                Id = obj.Id,
                AttractionId = obj.AttractionId,
                UserId = obj.UserId
            };
        }

        public static List<DAL.wish> Convert(List<DTO.WishDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.WishDTO> Convert(List<DAL.wish> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
