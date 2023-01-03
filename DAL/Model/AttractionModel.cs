using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class AttractionModel
    {
        public List<attraction> GetAttractions()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.attractions.Include("category").Include("images").Include("periods").Include("opinions").ToList();
            }
        }
        public List<attraction> GetAttractionsByUserId(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.attractions.Include("category").Include("images").Include("periods").Include("opinions").Where(x => x.ManagerId == id).ToList();
            }
        }


        public List<attraction> GetAttractionsByArea(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.attractions.Include("category").Where(x => x.ManagerId == id).ToList();
            }
        }
        public attraction GetAttractionByAttractionId(int attractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.attractions.Include("category").FirstOrDefault(x => x.Id == attractionId);
            }
        }
        public List<attraction> GetAttractionsByCategoryId(int categoryId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.attractions.Where(x => x.CategoryId == categoryId).ToList();
            }
        }
        
        public attraction Post(attraction attraction)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                attraction = db.attractions.Add(attraction);
                db.SaveChanges();
                return attraction;
            }
        }
        public attraction Put(attraction attraction)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
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
        }

        public attraction ChangeAttractionAvailable(int attractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                attraction a = db.attractions.FirstOrDefault(x => x.Id == attractionId);
                a.IsAvailable = !a.IsAvailable;
                db.SaveChanges();
                return a;
            }
        }
        public void UpdateUsers(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                OrderAttractionModel model = new OrderAttractionModel();
                List<orderAttraction> list = db.orderAttractions.Where(x => x.AttractionId == id).ToList();
                foreach (var item in list)
                {
                    item.IsApproval = !item.IsApproval;
                    model.SendMessage(item.user, item, "<h1> הודעה עבור הזמנתך " + item.attraction.Name + " </h1>", "<p> אנו מתנצלים אך האטרקציה נסגרה. כספך יוחזר בימים הקרובים לכל שאלה או מענה ניתן לפנות אלינו בטלפון " + item.attraction.Phone + "</p>");
                }
            }
        }
        public attraction ChangeAttractionStatus(int attractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                attraction a = db.attractions.Include("category").Include("images").Include("periods").Include("opinions").FirstOrDefault(x => x.Id == attractionId);
                a.Status = !a.Status;
                if (a.Status == false)
                    UpdateUsers(attractionId);
                db.SaveChanges();
                return a;
            }
        }
        public attraction Delete(attraction attraction)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                attraction newAttraction = db.attractions.Remove(attraction);
                db.SaveChanges();
                return attraction;
            }
        }
    }
}
