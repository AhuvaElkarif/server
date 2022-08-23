using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class ProductToOrderController : ApiController
    {
        BLL.Service.ProductToOrderService service = new BLL.Service.ProductToOrderService();
        [HttpGet]

        public List<DTO.ProductToOrderDTO> GetProductToOrders()
        {
            return service.GetProductToOrders();
        }

        public DTO.ProductToOrderDTO GetProductsByOrderAttractionId(int orderId)
        {
            return service.GetProductsByOrderAttractionId(orderId);
        }

        public DTO.ProductToOrderDTO GetProductsByAttractionId(int attractionId)
        {
            return service.GetProductsByAttractionId(attractionId);
        }

        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(ProductToOrderDTO productToOrder)
        {
            try
            {
                var p = service.Post(productToOrder);
                return Created("הזמנת המוצר התווספה", p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(ProductToOrderDTO productToOrder)
        {
            try
            {
                var p = service.Put(productToOrder);
                return Created("הזמנת המוצר עודכנה", p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(ProductToOrderDTO productToOrder)
        {
            try
            {
                var p = service.Delete(productToOrder);
                return Created("הזמנת המוצר נמחקה", p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}