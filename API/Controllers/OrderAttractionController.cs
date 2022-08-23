﻿using DTO;
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

        public DTO.OrderAttractionDTO GetOrdersByUserId(int userId)
        {
            return service.GetOrdersByUserId(userId);
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