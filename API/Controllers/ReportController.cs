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
        [HttpPut]
        [Route("Api/report/ChangeStatus")]
        public IHttpActionResult ChangeStatus(int reportId, string operation)
        {
            try
            {
                var o = service.ChangeStatus(reportId, operation);
                return Created("הדיווח עודכן", o);
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