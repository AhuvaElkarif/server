using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class CategoryConvert
    {
        public static DTO.CategoryDTO Convert(DAL.category obj)
        {
            if (obj == null)
                return null;
            return new DTO.CategoryDTO()
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

        public static DAL.category Convert(DTO.CategoryDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.category()
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

        public static List<DAL.category> Convert(List<DTO.CategoryDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.CategoryDTO> Convert(List<DAL.category> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
