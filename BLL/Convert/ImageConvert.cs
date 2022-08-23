using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class ImageConvert
    {
        public static DTO.ImageDTO Convert(DAL.image obj)
        {
            if (obj == null)
                return null;
            return new DTO.ImageDTO()
            {
                Id = obj.Id,
                Img = obj.Img,
                AttractionId=obj.AttractionId

            };
        }

        public static DAL.image Convert(DTO.ImageDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.image()
            {
                Id = obj.Id,
                Img = obj.Img,
                AttractionId=obj.AttractionId
            };
        }

        public static List<DAL.image> Convert(List<DTO.ImageDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.ImageDTO> Convert(List<DAL.image> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
