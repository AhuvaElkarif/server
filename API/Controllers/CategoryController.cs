using DTO;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Route("Api/category/GetWaitingCategory")]
        public List<DTO.CategoryDTO> GetWaitingCategory()
        {
            return service.GetWaitingCategory();
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
        [HttpPut]
        [Route("Api/category/ChangeStatus")]
        public IHttpActionResult ChangeStatus()
        {
            try
            {
                //string imageName = null;
                var httpReqest = HttpContext.Current.Request;
                // upload image
                var postedFile = httpReqest.Files["Img"];
                var FileName = httpReqest.Params["FileName"];
                var Id = httpReqest.Params["Id"];
                var Name = httpReqest.Params["Name"];
                byte[] data=null;
                if (postedFile != null)
                {
                    byte[] buffer = new byte[16 * 1024];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int read;
                        while ((read = postedFile.InputStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
                        //return ms.ToArray();
                        data = ms.ToArray();
                    }
                }
                CategoryDTO c = new CategoryDTO()
                {

                    Id = int.Parse(Id),
                    Img = FileName?.ToString(),
                    Name = Name,

                };
                var a = service.ChangeStatus(c, data);
                return Created("הססטוס עודכן", a);
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
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var a = service.Delete(id);
                return Created("הקטגוריה נמחקה", a);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}