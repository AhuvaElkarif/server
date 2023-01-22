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
        [Route("api/equipment/Post")]

        public IHttpActionResult Post(List<EquipmentDTO> equipment)
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
        [HttpPut]
        [Route("api/equipment/Put")]
        public IHttpActionResult Put(List<EquipmentDTO> equipment)
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
        [HttpDelete]
        [Route("api/equipment/Delete")]
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