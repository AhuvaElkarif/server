using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class SeasonModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();

        public List<season> GetSeasons()
        {
            return db.seasons.ToList();
        }

        public season GetSeasonBySeasonId(int id)
        {
            return db.seasons.FirstOrDefault(x => x.Id == id);
        }
        public season Post(season season)
        {
            season = db.seasons.Add(season);
            db.SaveChanges();
            return season;
        }
        public season Put(season season)
        {
            season newseason = db.seasons.FirstOrDefault(x => x.Id == season.Id);
            newseason.Name = season.Name;
            db.SaveChanges();
            return season;

        }

        public season Delete(season season)
        {
            season newseason = db.seasons.Remove(season);
            db.SaveChanges();
            return season;
        }
    }
}