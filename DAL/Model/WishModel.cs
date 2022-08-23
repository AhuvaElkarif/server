using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class WishModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();
        public List<wish> GetWishes()
        {
            return db.wishes.ToList();
        }
        public List<wish> GetWishesByUserId(int userId)
        {
            return db.wishes.Where(x => x.UserId == userId).ToList();
        }
        //public List<attraction> GetAttractionsById(int userId)
        //{
        //    return db.attractions.Where(x => x.wish.any(y => y.userId == userId)).ToList();
        //}
        public List<wish> GetWishesByAttractionId(int attractionId)
        {
            return db.wishes.Where(x => x.AttractionId == attractionId).ToList();
        }

        public wish Post(wish wish)
        {
            wish = db.wishes.Add(wish);
            db.SaveChanges();
            return wish;
        }
        public wish Put(wish wish)
        {
            wish newWish = db.wishes.FirstOrDefault(x => x.Id == wish.Id);
            db.SaveChanges();
            
            return wish;

        }
        public bool Delete(int wishId)
        {
            wish newWish = db.wishes.Remove(db.wishes.FirstOrDefault(x => x.Id == wishId));
            db.SaveChanges();
            return true;

        }
    }
}
