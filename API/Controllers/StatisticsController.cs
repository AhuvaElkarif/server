using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class StatisticsController : ApiController
    {
        BLL.Service.StatisticService service = new BLL.Service.StatisticService();
        [HttpGet]
        [Route("~/api/statistic/GetStatistic")]
        public DTO.StatisticsDTO GetStatistic()
        {
            return new DTO.StatisticsDTO()
            {
                CountUsers = service.GetCountUsers(),
                CountLost = service.GetCountLost()
            };
        }
    }
}
