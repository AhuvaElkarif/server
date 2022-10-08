using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ReportService
    {
        DAL.Model.ReportModel model = new DAL.Model.ReportModel();
        public List<DTO.ReportDTO> Get()
        {
            return Convert.ReportConvert.Convert(model.GetReports());
        }

        public DTO.ReportDTO GetreportByreportId(int reportId)
        {
            return Convert.ReportConvert.Convert(model.GetReportByreportId(reportId));
        }

        public DTO.ReportDTO Post(DTO.ReportDTO report)
        {
            return Convert.ReportConvert.Convert(model.Post(Convert.ReportConvert.Convert(report)));
        }
        public DTO.ReportDTO ChangeStatus(int reportId, string operation)
        {
            return Convert.ReportConvert.Convert(model.ChangeStatus(reportId, operation));
        }
        public DTO.ReportDTO Put(DTO.ReportDTO report)
        {
            return Convert.ReportConvert.Convert(model.Put(Convert.ReportConvert.Convert(report)));
        }

        public bool Delete(int reportId)
        {
            return model.Delete(reportId);
        }

    }
}

