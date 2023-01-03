using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class StatisticsModel
    {
        public List<PopularAttractions> GetPolpularAttractionsInLastYear()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                int now = DateTime.Now.Year-1;
                var cnt = db.orderAttractions.Where(x => x.Status == true && x.OrderDate.Year == now).Count();
                return db.orderAttractions.Where(x => x.Status == true && x.OrderDate.Year == now)
                .GroupBy(x => x.AttractionId).Select(x => new PopularAttractions() { label = db.attractions.FirstOrDefault(z => x.Key == z.Id).Name, y = x.Count()*100/cnt })
                .ToList();

            }
        }
        public List<PopularAttractions> GetRatingAreas()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.attractions.Where(x => x.Status == true).GroupBy(x=>x.AreaId)
                .Select(x => new PopularAttractions() { label = db.areas.FirstOrDefault(z => x.Key==z.Id).Name, y = x.Count() })
                .ToList();

            }
        }
        public int GetCountUsers()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.users.Where(x=> x.Active==true).Count();
            }
        }
        public int GetCountOrders()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.orderAttractions.Where(x => x.Status==true).Count();
            }
        }
        public int GetCountAttrctions()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.attractions.Where(x=>x.Status==true).Count();
            }
        }
    }
}
