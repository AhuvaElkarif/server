using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers 
{
    public class CategoryController : ApiController
    {
        BLL.Service.CategoryService service = new BLL.Service.CategoryService();
        [HttpGet]
        public List<DTO.CategoryDTO> Get()
        {
            return service.Get();
        }
        public DTO.CategoryDTO GetCategoryByCategoryId(int categoryId)
        {
            return service.GetCategoryByCategoryId(categoryId);
        }

        [HttpPost]
        //[Route("api/trip/post2")]
        public IHttpActionResult Post(CategoryDTO category)
        {
            try
            {
                var a = service.Post(category);
                return Created("הקטגוריה התווספה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(CategoryDTO category)
        {
            try
            {
                var a = service.Put(category);
                return Created("הקטגוריה עודכנה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(CategoryDTO category)
        {
            try
            {
                var a = service.Delete(category);
                return Created("הקטגוריה נמחקה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}