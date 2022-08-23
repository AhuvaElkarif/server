using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class ImageController : ApiController
    {
        BLL.Service.ImageService service = new BLL.Service.ImageService();

        [HttpGet]
        public List<DTO.ImageDTO> Getimage()
        {
            return service.Getimage();
        }

        public DTO.ImageDTO GetImageByImageId(int imageId)
        {
            return service.GetImageByImageId(imageId);
        }

        public List<DTO.ImageDTO> GetImagesByAttractionId(int attractionId)
        {
            return service.GetImagesByAttractionId(attractionId);
        }

        [HttpPost]
   
        public IHttpActionResult uploadImag()
        {
            try
            {
                //string imageName = null;
                var httpReqest = HttpContext.Current.Request;
                // upload image
                var postedFile = httpReqest.Files["Image"];
                var FileName = httpReqest.Params["FileName"];
                var Id = httpReqest.Params["Id"];

                byte[] buffer = new byte[16 * 1024];
                byte[] data;
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
                int.TryParse(Id, out int AttractionId);
                ImageDTO image = new ImageDTO()
                {

                   AttractionId= AttractionId,
                     Img = FileName?.ToString() + "." + postedFile.FileName.Split('.')[1],

                };
                image = service.Post(image,data);
                return Created("התמונה התווספה", image);
            }
            catch (Exception e)
            {
                return BadRequest("לא הצלחנו להוסיף את התמונה כדאי לנסות לשנות את השם");
            }


        }


        public IHttpActionResult Put(ImageDTO image)
        {
            try
            {
                var i = service.Put(image);
                return Created("התמונה עודכנה", i);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(ImageDTO image)
        {
            try
            {
                var i = service.Delete(image);
                return Created("התמונה נמחקה", i);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}