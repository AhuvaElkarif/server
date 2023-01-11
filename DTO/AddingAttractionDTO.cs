using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AddingAttractionDTO
    {
        public AttractionDTO Attraction { get; set; }
        public List<PeriodDTO> PeriodsList { get; set; }
        public List<ImageDTO> ImagesList { get; set; }
        public List<EquipmentDTO> EquipmentsList { get; set; }
        public UserDTO Manager { get; set; }

    }
}
