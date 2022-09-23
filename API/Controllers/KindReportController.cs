using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class KindReportController : ApiController
    {
        BLL.Service.KindReportService service = new BLL.Service.KindReportService();
        [HttpGet]
        public List<DTO.KindReportDTO> Get()
        {
            return service.Get();
        }
        public DTO.KindReportDTO GetkindReportByKindReportId(int kindReportId)
        {
            return service.GetkindReportBykindReportId(kindReportId);
        }

        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(KindReportDTO kindReport)
        {
            try
            {
                var a = service.Post(kindReport);
                return Created("סוג הדיווח התווסף", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(KindReportDTO kindReport)
        {
            try
            {
                var a = service.Put(kindReport);
                return Created("הדיווח עודכן", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(KindReportDTO kindReport)
        {
            try
            {
                var a = service.Delete(kindReport);
                return Created("הדיווח נמחק", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}