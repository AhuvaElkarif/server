using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class PeriodModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();
        public List<period> GetPeriods()
        {
            return db.periods.ToList();
        }
        public period GetPeriodByPeriodId(int periodId)
        {
            return db.periods.FirstOrDefault(x => x.Id == periodId);
        }
        public period Post(period period)
        {
            period = db.periods.Add(period);
            db.SaveChanges();
            return period;
        }
        public period Put(period period)
        {
            period newPeriod = db.periods.FirstOrDefault(x => x.Id == period.Id);
            newPeriod.FromDate = period.FromDate;
            newPeriod.Season = period.Season;
            newPeriod.TillDate = period.TillDate;
            db.SaveChanges();
            return period;

        }
        public period Delete(period period)
        {
            period newPeriod = db.periods.Remove(period);
            db.SaveChanges();
            return period;
        }
    }
}
