using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class PeriodController : ApiController
    {
        BLL.Service.PeriodService service = new BLL.Service.PeriodService();
        [HttpGet]
        public List<DTO.PeriodDTO> GetPeriods()
        {
            return service.GetPeriods();
        }
        [HttpGet]
        [Route("api/period/GetPeriodByAttractionId")]
        public List<DTO.PeriodDTO> GetPeriodByAttractionId(int attractionId)
        {
            return service.GetPeriodByAttractionId(attractionId);
        }
        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(PeriodDTO period)
        {
            try
            {
                var p = service.Post(period);
                return Created("משך הזמן התווסף", p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(PeriodDTO period)
        {
            try
            {
                var p = service.Put(period);
                return Created("התקופה עודכנה", p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(PeriodDTO period)
        {
            try
            {
                var p = service.Delete(period);
                return Created("התקופה נמחקה", p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
