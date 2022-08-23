using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class EquipmentController : ApiController
    {
        BLL.Service.EquipmentService service = new BLL.Service.EquipmentService();
        [HttpGet]

        public List<DTO.EquipmentDTO> Get()
        {
            return service.Get();
        }

        public DTO.EquipmentDTO GetEquipmentstByEquipmentId(int equipmentId)
        {
            return service.GetEquipmentstByEquipmentId(equipmentId);
        }

        public List<DTO.EquipmentDTO> GetEquipmentsByAttractionId(int attractionId)
        {
            return service.GetEquipmentsByAttractionId(attractionId);
        }
        [HttpPost]
        //[Route("api/trip/post2")]

        public IHttpActionResult Post(EquipmentDTO equipment)
        {
            try
            {
                var eq = service.Post(equipment);
                return Created("הציוד התווסף", eq);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(EquipmentDTO equipment)
        {
            try
            {
                var eq = service.Put(equipment);
                return Created("הציוד עודכן", eq);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(EquipmentDTO equipment)
        {
            try
            {
                var eq = service.Delete(equipment);
                return Created("הציוד נמחק", eq);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}