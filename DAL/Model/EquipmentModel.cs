using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class EquipmentModel
    {
        public List<equipment> Get()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.equipments.ToList();
            }
        }
        public equipment GetEquipmentstByEquipmentId(int equipmentId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.equipments.FirstOrDefault(x => x.Id == equipmentId);
            }

        }
        public List<equipment> GetEquipmentsByAttractionId(int attractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.equipments.Where(x => x.AttractionId == attractionId).ToList();
            }
        }
        public List<equipment> Post(List<equipment> equipment)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                foreach (var item in equipment)
                {
                    db.equipments.Add(item);
                }
                db.SaveChanges();
                return equipment;
            }
        }
        public List<equipment> Put(List<equipment> equipment)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                foreach (var item in equipment)
                {
                    equipment newEquipment = db.equipments.FirstOrDefault(x => x.Id == item.Id);
                    if (item.Name == "")
                        Delete(newEquipment);
                    else
                        newEquipment.Name = item.Name;
                }
                db.SaveChanges();
                return equipment;
            }
        }
        public bool Delete(equipment equipment)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                equipment newEquipment = db.equipments.Remove(db.equipments.FirstOrDefault(x => x.Id == equipment.Id));
                db.SaveChanges();
                return true;
            }
        }
    }
}
