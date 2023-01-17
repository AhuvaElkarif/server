using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class GeneralTimeModel
    {
        public List<generalTime> Get()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.generalTimes.ToList();
            }
        }
        public List<period> GetByAttractionId(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                List<period> dic = db.periods.Include("generalTimes").Where(x => x.AttractionId == id && x.TillDate >= DateTime.Now).ToList();
                if (dic.Count > 0)
                {
                    DateTime min = dic[0].FromDate;
                    period p = dic[0];
                    List<period> list;
                    foreach (period period in dic)
                    {
                        if (period.TillDate < min)
                        {
                            min = period.TillDate;
                            p = period;
                        }
                    }
                    list = db.periods.Include("generalTimes").Where(x => x.Id==p.Id && x.TillDate >= min && x.SeasonId == p.SeasonId && x.TillDate.Year == p.TillDate.Year).ToList();
                    //List<period> dic = db.periods.Include("generalTimes").Where(x => x.AttractionId == id).ToList();
                    return list;
                }
                return dic;
            }
        }
        public List<generalTime> GetGeneralTimesByPeriodId(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.generalTimes.Include("period").Where(x => x.PeriodId == id).ToList();

            }
        }
        public generalTime Post(generalTime generalTime)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                generalTime = db.generalTimes.Add(generalTime);
                db.SaveChanges();
                return generalTime;
            }
        }
        public generalTime Put(generalTime generalTime)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                generalTime newGeneralTime = db.generalTimes.FirstOrDefault(x => x.Id == generalTime.Id);
                newGeneralTime.DayInWeek = generalTime.DayInWeek;
                newGeneralTime.EndTime = generalTime.EndTime;
                newGeneralTime.StartTime = generalTime.StartTime;
                newGeneralTime.PeriodId = generalTime.PeriodId;
                db.SaveChanges();
                return generalTime;
            }

        }
        public bool Delete(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                generalTime newGeneralTime = db.generalTimes.Remove(db.generalTimes.FirstOrDefault(x => x.Id == id));
                db.SaveChanges();
                return true;
            }
        }
    }
}
