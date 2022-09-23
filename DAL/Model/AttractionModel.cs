using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class AttractionModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();

        public List<attraction> GetAttractions()
        {
            return db.attractions.ToList();
        }
        public List<attraction> GetAttractionsByUserId(int id)
        {
            return db.attractions.Where(x => x.ManagerId == id).ToList();
        }


        public List<attraction> GetAttractionsByArea(int id)
        {
            return db.attractions.Where(x => x.ManagerId == id).ToList();
        }
        public attraction GetAttractionByAttractionId(int attractionId)
        {
            return db.attractions.FirstOrDefault(x => x.Id == attractionId);
        }
        public List<attraction> GetAttractionsByCategoryId(int categoryId)
        {
            return db.attractions.Where(x => x.CategoryId == categoryId).ToList();
        }
        public attraction Post(attraction attraction)
        {
            attraction = db.attractions.Add(attraction);
            db.SaveChanges();
            return attraction;
        }
        public attraction Put(attraction attraction)
        {
            attraction newAttraction = db.attractions.FirstOrDefault(x => x.Id == attraction.Id);
            newAttraction.Address = attraction.Address;
            newAttraction.Name = attraction.Name;
            newAttraction.Date = attraction.Date;
            newAttraction.DaysToCancel = attraction.DaysToCancel;
            newAttraction.Description = attraction.Description;
            newAttraction.FromAge = attraction.FromAge;
            newAttraction.TillAge = attraction.TillAge;
            newAttraction.TimeDuration = attraction.TimeDuration;
            newAttraction.IsAvailable = attraction.IsAvailable;
            newAttraction.MaxParticipant = attraction.MaxParticipant;
            newAttraction.MinParticipant = attraction.MinParticipant;
            newAttraction.Price = attraction.Price;
            newAttraction.Status = attraction.Status;
            newAttraction.AreaId = attraction.AreaId;
            newAttraction.Phone = attraction.Phone;
            newAttraction.CategoryId = attraction.CategoryId;
            newAttraction.ManagerId = attraction.ManagerId;
            db.SaveChanges();
            return attraction;

        }

        public attraction ChangeAttractionAvailable(int attractionId)
        {
            attraction a = db.attractions.FirstOrDefault(x => x.Id == attractionId);
            a.IsAvailable = !a.IsAvailable;
            db.SaveChanges();
            return a;
        }
        public attraction ChangeAttractionStatus(int attractionId)
        {
            attraction a = db.attractions.FirstOrDefault(x => x.Id == attractionId);
            a.Status = !a.Status;
            db.SaveChanges();
            return a;
        }
        public attraction Delete(attraction attraction)
        {
            attraction newAttraction = db.attractions.Remove(attraction);
            db.SaveChanges();
            return attraction;
        }
    }
}
