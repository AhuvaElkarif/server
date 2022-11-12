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
        [Route("Api/user/GetManagersUsers")]
        public List<DTO.UserDTO> GetManagersUsers()
        {
            return service.GetManagersUsers();
        }
        public DTO.UserDTO GetUserByUserId(int userId)
        {
            return service.GetUserByUserId(userId);
        }
        public DTO.UserDTO GetUserByEmail(string email)
        {
            return service.GetUserByEmail(email);
        }
        
        [HttpPost]
       
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
        [Route("api/user/post2")]
        public IHttpActionResult Login(UserDTO user)
        {
            try
            {
                var u = service.Login(user);
                return Created("המשתמש התחבר", u);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
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
        [HttpPut]
        [Route("Api/user/ChangePassword")]
        public IHttpActionResult ChangePassword(UserDTO user)
        {
            try
            {
                var u = service.ChangePassword(user);
                return Created("המשתמש עודכן", u);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("Api/user/ChangeUsersStatus")]
        public IHttpActionResult ChangeUsersStatus(List<UserDTO> users)
        {
            try
            {
                var u = service.ChangeUsersStatus(users);
                return Created("המשתמשים עודכנו", u);
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