using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class GeneralTimeController : ApiController
    {

        BLL.Service.GeneralTimeService service = new BLL.Service.GeneralTimeService();

        [HttpGet]
        public List<DTO.GeneralTimeDTO> Get()
        {
            return service.Get();
        }

        public List< PeriodDTOWhitTime> GetByAttractionId(int attractionId)
        {
            var x= service.GetByAttractionId(attractionId);
            return x;
        }
        [HttpGet]
        [Route("api/generalTime/GetGeneralTimesByPeriodId")]
        public List<DTO.GeneralTimeDTO> GetGeneralTimesByPeriodId(int id)
        {
            return service.GetGeneralTimesByPeriodId(id);
        }

        [HttpPost]
        //[Route("api/trip/post2")]

        public IHttpActionResult Post(GeneralTimeDTO generalTime)
        {
            try
            {
                var gt = service.Post(generalTime);
                return Created("פרטים מזמן כללי התווסף", gt);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(GeneralTimeDTO generalTime)
        {
            try
            {
                var gt = service.Put(generalTime);
                return Created("פרטים מזמן כללי עודכנו", gt);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public IHttpActionResult Delete(int generalTimeId)
        {
            try
            {
                service.Delete(generalTimeId);
                return Ok("הזמנים נמחקו");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}