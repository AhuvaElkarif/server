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
            newAttraction.Name = attraction.Name;
            newAttraction.Address = attraction.Address;
            newAttraction.CategoryId = attraction.CategoryId;
            newAttraction.date = attraction.date;
            newAttraction.DaysToCancel = attraction.DaysToCancel;
            newAttraction.Description = attraction.Description;
            newAttraction.FromAge = attraction.FromAge;
            newAttraction.TillAge = attraction.TillAge;
            newAttraction.TimeDuration = attraction.TimeDuration;
            newAttraction.IsAvailable = attraction.IsAvailable;
            newAttraction.MaxParticipant = attraction.MaxParticipant;
            newAttraction.MinParticipant = attraction.MinParticipant;
            newAttraction.Price = attraction.Price;
            newAttraction.status = attraction.status;
            db.SaveChanges();
            return attraction;

        }
        public attraction Delete(attraction attraction)
        {
            attraction newAttraction = db.attractions.Remove(attraction);
            db.SaveChanges();
            return attraction;
        }
    }
}
