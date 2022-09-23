using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class AreaModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();

        public List<area> GetAreas()
        {
            return db.areas.ToList();
        }

        public area GetAreaByAreaId(int id)
        {
            return db.areas.FirstOrDefault(x => x.Id == id);
        }
        public area Post(area area)
        {
            area = db.areas.Add(area);
            db.SaveChanges();
            return area;
        }
        public area Put(area area)
        {
            area newArea = db.areas.FirstOrDefault(x => x.Id == area.Id);
            newArea.Name = area.Name;
            db.SaveChanges();
            return area;

        }

        public area Delete(area area)
        {
            area newArea = db.areas.Remove(area);
            db.SaveChanges();
            return area;
        }
    }
}