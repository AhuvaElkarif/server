using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class EquipmentConvert
    {
        public static DTO.EquipmentDTO Convert(DAL.equipment obj)
        {
            if (obj == null)
                return null;
            return new DTO.EquipmentDTO()
            {
                Id = obj.Id,
                AttractionId = obj.AttractionId,
                Name=obj.Name
            };
        }

        public static DAL.equipment Convert(DTO.EquipmentDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.equipment()
            {
                Id = obj.Id,
                AttractionId = obj.AttractionId,
                Name = obj.Name
            };
        }

        public static List<DAL.equipment> Convert(List<DTO.EquipmentDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.EquipmentDTO> Convert(List<DAL.equipment> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
