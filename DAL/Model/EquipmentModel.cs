using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class EquipmentModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();
        public List<equipment> Get()
        {
            return db.equipments.ToList();
        }
        public equipment GetEquipmentstByEquipmentId(int equipmentId)
        {
            return db.equipments.FirstOrDefault(x => x.Id == equipmentId);

        }
        public List<equipment> GetEquipmentsByAttractionId(int attractionId)
        {

            return db.equipments.Where(x => x.AttractionId == attractionId).ToList();
        }
        public equipment Post(equipment equipment)
        {

            equipment = db.equipments.Add(equipment);
            db.SaveChanges();
            return equipment;
        }
        public equipment Put(equipment equipment)
        {

            equipment newEquipment = db.equipments.FirstOrDefault(x => x.Id == equipment.Id);
            newEquipment.Name = equipment.Name;
            db.SaveChanges();
            return equipment;
        }
        public equipment Delete(equipment equipment)
        {
            equipment newEquipment = db.equipments.Remove(equipment);
            db.SaveChanges();
            return equipment;
        }
    }
}
