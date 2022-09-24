using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class CategoryModel
    {
        public List<category> Get()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.categories.Where(x => x.Status == true).ToList();
            }
        }

        public List<category> GetWaitingCategory()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.categories.Where(x => x.Status == false).ToList();
            }
        }
        public category GetCategoryByCategoryId(int categoryId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.categories.FirstOrDefault(x => x.Id == categoryId);
            }
        }
        public category Post(category category)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                category = db.categories.Add(category);
                db.SaveChanges();
                return category;
            }
        }

        public category ChangeStatus(category category)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                category newCategory = db.categories.FirstOrDefault(x => x.Id == category.Id);
                newCategory.Status = !newCategory.Status;
                db.SaveChanges();
                return category;
            }
        }
        public category Put(category category)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                category newCategory = db.categories.FirstOrDefault(x => x.Id == category.Id);
                newCategory.Name = category.Name;
                newCategory.Status = category.Status;
                db.SaveChanges();
                return category;
            }
        }
        public category Delete(category category)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                category newCategory = db.categories.Remove(category);
                db.SaveChanges();
                return category;
            }
        }
    }
}
