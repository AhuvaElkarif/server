using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class OrderAttractionController : ApiController
    {
        BLL.Service.OrderAttractionService service = new BLL.Service.OrderAttractionService();
        [HttpGet]
        public List<DTO.OrderAttractionDTO> GetOrders()
        {
            return service.GetOrders();
        }
        public DTO.OrderAttractionDTO GetOrdersByOrderAttractionId(int orderAttractionId)
        {
            return service.GetOrdersByOrderAttractionId(orderAttractionId);
        }

        [Route("Api/orderAttraction/GetordersByUserId")]
        public List<DTO.OrderAttractionDTO> GetOrdersByUserId(int userId)
        {
            return service.GetOrdersByUserId(userId);
        }

        [Route("Api/orderAttraction/GetordersByManagerId")]
        public List<OrderAttractionDTO> GetordersByManagerId(int managerId)
        {
            return service.GetOrdersByManagerId(managerId);
        }
        [Route("Api/orderAttraction/GetDaysInMonth")]
        public List<EventsInCalenderDTO> GetDaysInMonth(int id, int month, int year, int amount)
        {
            return service.GetDaysInMonth(id, month, year, amount);
        }
        [HttpPut]
        public IHttpActionResult ChangeOrderStaus(int orderId)
        {
            try
            {
                var a = service.ChangeStatus(orderId);
                return Created("הזמנת אטרקציה שונתה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("Api/orderAttraction/ChangeApproval")]
        public IHttpActionResult ChangeApproval(int id)
        {
            try
            {
                var a = service.ChangeApproval(id);
                return Created("אישור אטרקציה שונה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(OrderAttractionDTO orderAttraction)
        {
            try
            {
                var a = service.Post(orderAttraction);
                return Created("הזמנת אטרקציה התווספה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(OrderAttractionDTO orderAttraction)
        {
            try
            {
                var a = service.Put(orderAttraction);
                return Created("הזמנת אטרקציה עודכנה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(OrderAttractionDTO orderAttraction)
        {
            try
            {
                var a = service.Delete(orderAttraction);
                return Created("הזמנת אטרקציה נמחקה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}