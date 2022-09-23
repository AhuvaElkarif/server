using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class SeasonController : ApiController
    {
        BLL.Service.SeasonService service = new BLL.Service.SeasonService();
        [HttpGet]
        public List<DTO.SeasonDTO> Get()
        {
            return service.Get();
        }
        public DTO.SeasonDTO GetSeasonBySeasonId(int seasonId)
        {
            return service.GetseasonByseasonId(seasonId);
        }

        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(DTO.SeasonDTO season)
        {
            try
            {
                var a = service.Post(season);
                return Created("האזור התווסף", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(DTO.SeasonDTO Season)
        {
            try
            {
                var a = service.Put(Season);
                return Created("האזור עודכן", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(DTO.SeasonDTO season)
        {
            try
            {
                var a = service.Delete(season);
                return Created("האזור נמחק", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}