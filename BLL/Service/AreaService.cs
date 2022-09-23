using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AreaService
    {
        DAL.Model.AreaModel model = new DAL.Model.AreaModel();
        public List<DTO.AreaDTO> Get()
        {
            return Convert.AreaConvert.Convert(model.GetAreas());
        }

        public DTO.AreaDTO GetAreaByAreaId(int areaId)
        {
            return Convert.AreaConvert.Convert(model.GetAreaByAreaId(areaId));
        }

        public DTO.AreaDTO Post(DTO.AreaDTO area)
        {
            return Convert.AreaConvert.Convert(model.Post(Convert.AreaConvert.Convert(area)));
        }

        public DTO.AreaDTO Put(DTO.AreaDTO area)
        {
            return Convert.AreaConvert.Convert(model.Put(Convert.AreaConvert.Convert(area)));
        }

        public DTO.AreaDTO Delete(DTO.AreaDTO area)
        {
            return Convert.AreaConvert.Convert(model.Delete(Convert.AreaConvert.Convert(area)));
        }

    }
}

