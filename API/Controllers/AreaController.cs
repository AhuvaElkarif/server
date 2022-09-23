using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class AreaController : ApiController
    {
        BLL.Service.AreaService service = new BLL.Service.AreaService();
        [HttpGet]
        public List<DTO.AreaDTO> Get()
        {
            return service.Get();
        }
        public DTO.AreaDTO GetAreaByAreaId(int areaId)
        {
            return service.GetAreaByAreaId(areaId);
        }

        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(AreaDTO area)
        {
            try
            {
                var a = service.Post(area);
                return Created("האזור התווסף", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(AreaDTO area)
        {
            try
            {
                var a = service.Put(area);
                return Created("האזור עודכן", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(AreaDTO area)
        {
            try
            {
                var a = service.Delete(area);
                return Created("האזור נמחק", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}