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
        public List<DTO.PopularAttractionsDTO> GetPolpularAttractionsInLastYear()
        {

            return Convert.StatistictsConvert.Convert( model.GetPolpularAttractionsInLastYear());
        }
        public int GetCountUsers()
        {
            return model.GetCountUsers();
        }
        public int GetCountOrders()
        {
            return model.GetCountOrders();
        }
        public int GetCountAttrctions()
        {
            return model.GetCountAttrctions();
        }
        public List<DTO.PopularAttractionsDTO> GetRatingAreas()
        {
            return Convert.StatistictsConvert.Convert(model.GetRatingAreas());

        }

    }
}
