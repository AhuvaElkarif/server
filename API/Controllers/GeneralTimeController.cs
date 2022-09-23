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

        public DTO.GeneralTimeDTO GetByGeneralTimeId(int generalTimeId)
        {
            return service.GetByGeneralTimeId(generalTimeId);
        }

        public List<DTO.GeneralTimeDTO> GetGeneralTimesByAttractionId(int attractionId)
        {
            return service.GetGeneralTimesByAttractionId(attractionId);
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

        public IHttpActionResult Delete(GeneralTimeDTO generalTime)
        {
            try
            {
                var gt = service.Delete(generalTime);
                return Created("פרטים מזמן כללי נמחקו", gt);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}