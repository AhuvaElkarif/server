using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class GeneralTimeModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();
        public List<generalTime> Get()
        {
            return db.generalTimes.ToList();
        }
        public generalTime GetByGeneralTimeId(int generalTimeId)
        {
            return db.generalTimes.FirstOrDefault(x => x.Id == generalTimeId);
        }
        public generalTime GetGeneralTimesByAttractionId(int attractionId)
        {
            return db.generalTimes.FirstOrDefault(x => x.AttractionId == attractionId);
        }
        public generalTime Post(generalTime generalTime)
        {
            generalTime = db.generalTimes.Add(generalTime);
            db.SaveChanges();
            return generalTime;
        }
        public generalTime Put(generalTime generalTime)
        {
            generalTime newGeneralTime = db.generalTimes.FirstOrDefault(x => x.Id == generalTime.Id);
            newGeneralTime.DayInWeek = generalTime.DayInWeek;
            newGeneralTime.EndTime = generalTime.EndTime;
            newGeneralTime.StartTime = generalTime.StartTime;
            newGeneralTime.AttractionId = generalTime.AttractionId;
            newGeneralTime.PeriodId = generalTime.PeriodId;
            db.SaveChanges();
            return generalTime;

        }
        public generalTime Delete(generalTime generalTime)
        {
            generalTime newGeneralTime = db.generalTimes.Remove(generalTime);
            db.SaveChanges();
            return generalTime;

        }
    }
}
