using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class AboutModel
    {
        public List<about> Get()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.abouts.Where(x=> x.Status==true).ToList();
            }
        }
       
        public about Post(about about)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                about = db.abouts.Add(about);
                db.SaveChanges();
                return about;
            }
        }

       
        public about Put(about about)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                about newabout = db.abouts.FirstOrDefault(x => x.Id == about.Id);
                newabout.HeaderText = about.HeaderText;
                newabout.ContentText = about.ContentText;
                newabout.Status = newabout.Status;
                db.SaveChanges();
                return about;
            }
        }
        public bool Delete(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                about newabout = db.abouts.FirstOrDefault(x => x.Id == id);
                newabout.Status = !newabout.Status;
                db.SaveChanges();
                return true;
            }
        }
    }
}
