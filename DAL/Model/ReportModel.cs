using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ReportModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();

        public List<report> GetReports()
        {
            return db.reports.ToList();
        }

        public report GetReportByreportId(int id)
        {
            return db.reports.FirstOrDefault(x => x.Id == id);
        }
        public report Post(report report)
        {
            report = db.reports.Add(report);
            db.SaveChanges();
            return report;
        }
        public report Put(report report)
        {
            report newReport = db.reports.FirstOrDefault(x => x.Id == report.Id);
            newReport.AttractionId = report.AttractionId;
            newReport.UserId = report.UserId;
            newReport.ReportId = report.ReportId;
            db.SaveChanges();
            return report;

        }

        public bool Delete(int reportId)
        {
            report newReport = db.reports.Remove(db.reports.FirstOrDefault(x => x.Id == reportId));
            db.SaveChanges();
            return true;
        }
    }
}