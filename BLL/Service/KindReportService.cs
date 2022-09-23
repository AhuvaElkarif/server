using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class KindReportService
    {
        DAL.Model.KindReportModel model = new DAL.Model.KindReportModel();
        public List<DTO.KindReportDTO> Get()
        {
            return Convert.KindReportConvert.Convert(model.GetKindReports());
        }

        public DTO.KindReportDTO GetkindReportBykindReportId(int kindReportId)
        {
            return Convert.KindReportConvert.Convert(model.GetKindReportByKindReportId(kindReportId));
        }

        public DTO.KindReportDTO Post(DTO.KindReportDTO kindReport)
        {
            return Convert.KindReportConvert.Convert(model.Post(Convert.KindReportConvert.Convert(kindReport)));
        }

        public DTO.KindReportDTO Put(DTO.KindReportDTO kindReport)
        {
            return Convert.KindReportConvert.Convert(model.Put(Convert.KindReportConvert.Convert(kindReport)));
        }

        public DTO.KindReportDTO Delete(DTO.KindReportDTO kindReport)
        {
            return Convert.KindReportConvert.Convert(model.Delete(Convert.KindReportConvert.Convert(kindReport)));
        }

    }
}


