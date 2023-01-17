using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class EquipmentService
    {
        DAL.Model.EquipmentModel model = new DAL.Model.EquipmentModel();

        public List<DTO.EquipmentDTO> Get()
        {
            return Convert.EquipmentConvert.Convert(model.Get());
        }

        public DTO.EquipmentDTO GetEquipmentstByEquipmentId(int equipmentId)
        {
            return Convert.EquipmentConvert.Convert(model.GetEquipmentstByEquipmentId(equipmentId));
        }

        public List<DTO.EquipmentDTO> GetEquipmentsByAttractionId(int attractionId)
        {
            return Convert.EquipmentConvert.Convert(model.GetEquipmentsByAttractionId(attractionId));
        }

        public List<DTO.EquipmentDTO> Post(List<EquipmentDTO> equipment)
        {
            return Convert.EquipmentConvert.Convert(model.Post(Convert.EquipmentConvert.Convert(equipment)));
        }

        public List<DTO.EquipmentDTO> Put(List<EquipmentDTO> equipment)
        {
            return Convert.EquipmentConvert.Convert(model.Put(Convert.EquipmentConvert.Convert(equipment)));
        }

        public bool Delete(List<EquipmentDTO> equipment)
        {
            return model.Delete(Convert.EquipmentConvert.Convert(equipment));
        }

    }
}
