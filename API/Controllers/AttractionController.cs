using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class AttractionController : ApiController
    {
        BLL.Service.AttractionService service = new BLL.Service.AttractionService();
        [HttpGet]
        public List<DTO.AttractionDTO> GetAttractions()
        {
            return service.GetAttractions();
        }
        public List<DTO.AttractionDTO> GetAttractionsByCategoryId(int categoryId)
        {
            return service.GetAttractionsByCategoryId(categoryId);
        }
        public DTO.AttractionDTO GetAttractionByAttractionId(int attractionId)
        {
            return service.GetAttractionByAttractionId(attractionId);
        }

        //action/GetAttractions
        //actios/2
        // actions?id=2
        public List<DTO.AttractionDTO> GetAttractionsByUserId(int userId)
        {
            return service.GetAttractionsByUserId(userId);
            //try
            //{
            //    var a = service.GetAttractionsByUserId(id);
            //    return Created("האטרקציות התקבלו לפי קוד משתמש", a);
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.Message);
            //}
        }
        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(AttractionDTO attraction)
        {
            try
            {
                var a = service.Post(attraction);
                return Created("האטרקציה התווספה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(AttractionDTO attraction)
        {
            try
            {
                var a = service.Put(attraction);
                return Created("האטרקציה עודכנה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(AttractionDTO attraction)
        {
            try
            {
                var a = service.Delete(attraction);
                return Created("האטרקציה נמחקה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
