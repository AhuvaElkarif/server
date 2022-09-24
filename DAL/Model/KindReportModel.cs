using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class KindReportModel
    {
        public List<kindReport> GetKindReports()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.kindReports.ToList();
            }
        }

        public kindReport GetKindReportByKindReportId(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.kindReports.FirstOrDefault(x => x.Id == id);
            }
        }
        public kindReport Post(kindReport kindReport)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                kindReport = db.kindReports.Add(kindReport);
                db.SaveChanges();
                return kindReport;
            }
        }
        public kindReport Put(kindReport kindReport)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                kindReport newkindReport = db.kindReports.FirstOrDefault(x => x.Id == kindReport.Id);
                newkindReport.Name = kindReport.Name;
                db.SaveChanges();
                return kindReport;
            }
        }

        public kindReport Delete(kindReport kindReport)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                kindReport newkindReport = db.kindReports.Remove(kindReport);
                db.SaveChanges();
                return kindReport;
            }
        }
    }
}