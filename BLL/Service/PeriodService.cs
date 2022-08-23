using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class PeriodService
    {
        DAL.Model.PeriodModel model = new DAL.Model.PeriodModel();

        public List<DTO.PeriodDTO> GetPeriods()
        {
            return Convert.PeriodConvert.Convert(model.GetPeriods());
        }

        public DTO.PeriodDTO GetPeriodByPeriodId(int periodId)
        {
            return Convert.PeriodConvert.Convert(model.GetPeriodByPeriodId(periodId));
        }

        public DTO.PeriodDTO Post(PeriodDTO period)
        {
            return Convert.PeriodConvert.Convert(model.Post(Convert.PeriodConvert.Convert(period)));
        }

        public DTO.PeriodDTO Put(PeriodDTO period)
        {
            return Convert.PeriodConvert.Convert(model.Put(Convert.PeriodConvert.Convert(period)));
        }

        public DTO.PeriodDTO Delete(PeriodDTO period)
        {
            return Convert.PeriodConvert.Convert(model.Delete(Convert.PeriodConvert.Convert(period)));
        }
    }
}
