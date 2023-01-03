using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StatisticsDTO
    {
        public List<PopularAttractionsDTO> Popular { get; set; }
        public List<PopularAttractionsDTO> Areas { get; set; }

        public int CountUsers { get; set; }
        public int CountOrders { get; set; }
        public int CountAttractions { get; set; }


    }
}
