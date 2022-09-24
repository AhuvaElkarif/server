using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class SeasonModel
    {
        public List<season> GetSeasons()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.seasons.ToList();
            }
        }

        public season GetSeasonBySeasonId(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.seasons.FirstOrDefault(x => x.Id == id);
            }
        }
        public season Post(season season)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                season = db.seasons.Add(season);
                db.SaveChanges();
                return season;
            }
        }
        public season Put(season season)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                season newseason = db.seasons.FirstOrDefault(x => x.Id == season.Id);
                newseason.Name = season.Name;
                db.SaveChanges();
                return season;
            }
        }

        public season Delete(season season)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                season newseason = db.seasons.Remove(season);
                db.SaveChanges();
                return season;
            }
        }
    }
}