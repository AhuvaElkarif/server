using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class StatisticsModel
    {
        public int GetCountUsers()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.users.Count();
            }
        }
        public int GetCountLost()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.attractions.Where(x => x.Id == 1).Count();
            }
        }
    }
}
