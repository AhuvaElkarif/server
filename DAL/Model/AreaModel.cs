using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class AreaModel
    {
        public List<area> GetAreas()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.areas.ToList();
            }
        }

        public area GetAreaByAreaId(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.areas.FirstOrDefault(x => x.Id == id);
            }
        }
        public area Post(area area)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                area = db.areas.Add(area);
                db.SaveChanges();
                return area;
            }
        }
        public area Put(area area)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                area newArea = db.areas.FirstOrDefault(x => x.Id == area.Id);
                newArea.Name = area.Name;
                db.SaveChanges();
                return area;
            }
        }

        public area Delete(area area)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                area newArea = db.areas.Remove(area);
                db.SaveChanges();
                return area;
            }
        }
    }
}