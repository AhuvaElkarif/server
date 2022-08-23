using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class UserController : ApiController
    {

        BLL.Service.UserService service = new BLL.Service.UserService();
        [HttpGet]
        public List<DTO.UserDTO> GetUsers()
        {
            return service.GetUsers();
        }

        public DTO.UserDTO GetUserByUserId(int userId)
        {
            return service.GetUserByUserId(userId);
        }

        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(UserDTO user)
        {
            try
            {
                var u = service.Post(user);
                return Created("המשתמש התווסף", u);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(UserDTO user)
        {
            try
            {
                var u = service.Put(user);
                return Created("המשתמש עודכן", u);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(int user)
        {
            try
            {
                service.Delete(user);
                return Ok("המשתמש נמחק");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}