using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class OpinionController : ApiController
    {
        BLL.Service.OpinionService service = new BLL.Service.OpinionService();

        [HttpGet]
        public List<DTO.OpinionDTO> GetOpinions()
        {
            return service.GetOpinions();
        }

        [Route("Api/opinion/GetNotActiveOpinions")]
        public List<DTO.OpinionDTO> GetNotActiveOpinions()
        {
            return service.GetNotActiveOpinions();
        }

        public DTO.OpinionDTO GetOpinionByopinionId(int opinionId)
        {
            return service.GetOpinionByopinionId(opinionId);
        }

        public List<DTO.OpinionDTO> GetOpinionsByAttrctionId(int attractionId)
        {
            return service.GetOpinionsByAttrctionId(attractionId);
        }

        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(OpinionDTO opinion)
        {
            try
            {
                var o = service.Post(opinion);
                return Created("חוות דעת התווספה", o);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IHttpActionResult ChangeStatus(int opinionId)
        {
            try
            {
                var o = service.ChangeStatus(opinionId);
                return Created("חוות דעת עודכנה", o);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        public IHttpActionResult Put(OpinionDTO opinion)
        {
            try
            {
                var o = service.Put(opinion);
                return Created("חוות דעת עודכנה", o);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(int opinionId)
        {
            try
            {
                var o = service.Delete(opinionId);
                return Created("חוות דעת נמחקה", o);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}