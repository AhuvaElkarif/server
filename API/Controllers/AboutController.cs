using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class AboutController : ApiController
    {
        BLL.Service.AboutService service = new BLL.Service.AboutService();
        [HttpGet]
        public List<DTO.AboutDTO> Get()
        {
            return service.Get();
        }
      

        [HttpPost]
        public IHttpActionResult Post(AboutDTO about)
        {
            try
            {
                var a = service.Post(about);
                return Created("האזור התווסף", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(AboutDTO about)
        {
            try
            {
                var a = service.Put(about);
                return Created("האזור עודכן", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("api/about/change")]
        public IHttpActionResult ChangeStatus(int id)
        {
            try
            {
                var a = service.Delete(id);
                return Created("האזור נמחק", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}