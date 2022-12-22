using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class AboutConvert
    {
        public static DTO.AboutDTO Convert(DAL.about obj)
        {
            if (obj == null)
                return null;
            return new DTO.AboutDTO()
            {
                Id = obj.Id,
               ContentText = obj.ContentText,
               HeaderText = obj.HeaderText,
                Status = obj.Status
            };
        }

        public static DAL.about Convert(DTO.AboutDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.about()
            {
                Id = obj.Id,
                ContentText = obj.ContentText,
                HeaderText = obj.HeaderText,
                Status= obj.Status
            };
        }

        public static List<DAL.about> Convert(List<DTO.AboutDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.AboutDTO> Convert(List<DAL.about> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}