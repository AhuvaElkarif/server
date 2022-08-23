using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class WishController: ApiController
    {

        BLL.Service.WishService service = new BLL.Service.WishService();
        [HttpGet]
        public List<DTO.WishDTO> GetWishes()
        {
            return service.GetWishes().ToList();
        }

        public List<DTO.WishDTO> GetWishesByUserId(int userId)
        {
            return service.GetWishesByUserId(userId).ToList();
        }

        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(DTO.WishDTO wish)
        {
            try
            {
                var u = service.Post(wish);
                return Created("המשאלה התווסף", u);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(DTO.WishDTO wish)
        {
            try
            {
                var w = service.Put(wish);
                return Created("המשאלה עודכנה", w);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(int wishId)
        {
            try
            {
                service.Delete(wishId);
                return Ok("המשאלה נמחק");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
