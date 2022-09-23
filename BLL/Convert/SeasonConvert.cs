using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class SeasonConvert
    {
        public static DTO.SeasonDTO Convert(DAL.season obj)
        {
            if (obj == null)
                return null;
            return new DTO.SeasonDTO()
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

        public static DAL.season Convert(DTO.SeasonDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.season()
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

        public static List<DAL.season> Convert(List<DTO.SeasonDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.SeasonDTO> Convert(List<DAL.season> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}