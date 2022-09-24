using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class WishModel
    {
        public List<wish> GetWishes()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.wishes.ToList();
            }
        }
        public List<attraction> GetWishesByUserId(int userId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.attractions.Where(x => x.wishes.Any(y => y.UserId == userId)).ToList();
            }
        }
        //public List<attraction> GetAttractionsById(int userId)
        //{
        //    return db.attractions.Where(x => x.wish.any(y => y.userId == userId)).ToList();
        //}
        public List<wish> GetWishesByAttractionId(int attractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.wishes.Where(x => x.AttractionId == attractionId).ToList();
            }
        }

        public wish Post(wish wish)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                wish = db.wishes.Add(wish);
                db.SaveChanges();
                return wish;
            }
        }
        public wish Put(wish wish)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                wish newWish = db.wishes.FirstOrDefault(x => x.Id == wish.Id);
                db.SaveChanges();

                return wish;
            }
        }
        public bool Delete(int attractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                wish newWish = db.wishes.Remove(db.wishes.FirstOrDefault(x => x.AttractionId == attractionId));
                db.SaveChanges();
                return true;
            }
        }
    }
}
