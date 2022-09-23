using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class AreaConvert
    {
        public static DTO.AreaDTO Convert(DAL.area obj)
        {
            if (obj == null)
                return null;
            return new DTO.AreaDTO()
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

        public static DAL.area Convert(DTO.AreaDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.area()
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

        public static List<DAL.area> Convert(List<DTO.AreaDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.AreaDTO> Convert(List<DAL.area> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}