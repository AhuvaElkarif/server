using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class PeriodModel
    {
        public List<period> GetPeriods()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.periods.ToList();
            }
        }
        public period GetPeriodByPeriodId(int periodId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.periods.FirstOrDefault(x => x.Id == periodId);
            }
        }
        public period Post(period period)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                period = db.periods.Add(period);
                db.SaveChanges();
                return period;
            }
        }
        public period Put(period period)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                period newPeriod = db.periods.FirstOrDefault(x => x.Id == period.Id);
                newPeriod.FromDate = period.FromDate;
                newPeriod.SeasonId = period.SeasonId;
                newPeriod.TillDate = period.TillDate;
                db.SaveChanges();
                return period;
            }
        }
        public period Delete(period period)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                period newPeriod = db.periods.Remove(period);
                db.SaveChanges();
                return period;
            }
        }
    }
}
