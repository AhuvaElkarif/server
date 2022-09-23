using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class ReportController :ApiController
    {
        BLL.Service.ReportService service = new BLL.Service.ReportService();
        [HttpGet]
        public List<DTO.ReportDTO> Get()
        {
            return service.Get();
        }
        public DTO.ReportDTO GetreportByreportId(int reportId)
        {
            return service.GetreportByreportId(reportId);
        }

        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(ReportDTO report)
        {
            try
            {
                var a = service.Post(report);
                return Created("הדיווח התווסף", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(ReportDTO report)
        {
            try
            {
                var a = service.Put(report);
                return Created("הדיווח עודכן", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(int reportId)
        {
            try
            {
                var a = service.Delete(reportId);
                return Created("הדיווח נמחק", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}