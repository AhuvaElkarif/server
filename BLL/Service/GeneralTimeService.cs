using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class GeneralTimeService
    {
        DAL.Model.GeneralTimeModel model = new DAL.Model.GeneralTimeModel();

        public List<DTO.GeneralTimeDTO> Get()
        {
            return Convert.GeneralTimeConvert.Convert(model.Get());
        }

        public  List<PeriodDTOWhitTime> GetByAttractionId(int id)
        {
            return Convert.GeneralTimeConvert.Convert(model.GetByAttractionId(id));
        }

        public List<DTO.GeneralTimeDTO> GetGeneralTimesByPeriodId(int id)
        {
            return Convert.GeneralTimeConvert.Convert(model.GetGeneralTimesByPeriodId(id));
        }

        public DTO.GeneralTimeDTO Post(GeneralTimeDTO generalTime)
        {
            return Convert.GeneralTimeConvert.Convert(model.Post(Convert.GeneralTimeConvert.Convert(generalTime)));
        }

        public DTO.GeneralTimeDTO Put(GeneralTimeDTO generalTime)
        {
            return Convert.GeneralTimeConvert.Convert(model.Put(Convert.GeneralTimeConvert.Convert(generalTime)));
        }

        public bool Delete(int id)
        {
            return model.Delete(id);
        }

    }
}
