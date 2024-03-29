﻿using System;
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
        public List<period> GetPeriodByAttractionId(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.periods.Where(x => x.AttractionId == id).ToList();
            }
        }
        public bool CheckRangeBetweenDates(period p)
        {
            if (p.FromDate > p.TillDate)
                return false;
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                if (db.periods.FirstOrDefault(x => x.AttractionId == p.AttractionId && (p.FromDate >= x.FromDate && p.FromDate <= x.TillDate ||
                                                                                        p.TillDate >= x.FromDate && p.TillDate <= x.TillDate ||
                                                                                        x.FromDate > p.FromDate && x.TillDate < p.TillDate)) != null)

                    return false;
            }
            return true;
        }
        public int GetSeasonId(period p)
        {
            int monthFrom = p.FromDate.Month;
            int monthTill = p.TillDate.Month;

            if (monthFrom >= 1 && monthTill <= 3)
                return 2;
            else
                 if (monthFrom >= 4 && monthTill <= 6)
                return 3;
            else
                 if (monthFrom >= 7 && monthTill <= 9)
                return 4;
            else
                return 1;
        }
        public period Post(period period)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                period.SeasonId = GetSeasonId(period);
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
                newPeriod.IsOpen = period.IsOpen;
                newPeriod.TillDate = period.TillDate;
                newPeriod.SeasonId = GetSeasonId(period);
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
