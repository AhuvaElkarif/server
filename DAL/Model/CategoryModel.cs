using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class CategoryModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();
        public List<category> Get()
        {
            return db.categories.ToList();
        }
        public category GetCategoryByCategoryId(int categoryId)
        {
            return db.categories.FirstOrDefault(x => x.Id == categoryId);
        }
        public category Post(category category)
        {
            category = db.categories.Add(category);
            db.SaveChanges();
            return category;
        }
        public category Put(category category)
        {
            category newCategory = db.categories.FirstOrDefault(x => x.Id == category.Id);
            newCategory.Name = category.Name;
            db.SaveChanges();
            return category;
        }
        public category Delete(category category)
        {
            category newCategory = db.categories.Remove(category);
            db.SaveChanges();
            return category;
        }
    }
}
