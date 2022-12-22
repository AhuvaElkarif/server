using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class StatisticService
    {
        DAL.Model.StatisticsModel model = new DAL.Model.StatisticsModel();
        public int GetCountUsers()
        {

            return model.GetCountUsers();
        }
        public int GetCountLost()
        {
            return model.GetCountLost();
        }

    }
}
