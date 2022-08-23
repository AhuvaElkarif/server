using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ImageService
    {
        DAL.Model.ImageModel model = new DAL.Model.ImageModel();

        public List<DTO.ImageDTO> Getimage()
        {
            return Convert.ImageConvert.Convert(model.Getimage());
        }

        public DTO.ImageDTO GetImageByImageId(int imageId)
        {
            return Convert.ImageConvert.Convert(model.GetImageByImageId(imageId));
        }

        public List<DTO.ImageDTO> GetImagesByAttractionId(int attractionId)
        {
            return Convert.ImageConvert.Convert(model.GetImageByAttractionId(attractionId));
        }

        public DTO.ImageDTO Post(ImageDTO image,byte[] data)
        {
            uploadImgBytes(image.Img, data);
            return Convert.ImageConvert.Convert(model.Post(Convert.ImageConvert.Convert(image)));
        }

        public void uploadImgBytes(string FileName,byte[] data)
        {
            
            string full = Path.Combine(@"C:\inetpub\wwwroot\image");
            if (!Directory.Exists(full))
            {
                Directory.CreateDirectory(full);
            }
            full = Path.Combine(full + "/" + FileName);
            if (File.Exists(full))
            {
                File.Delete(full);
            }
            using (Stream file = File.OpenWrite(full))
            {
                byte[] t = data;
                file.Write(t, 0, t.Length);
                file.Close();
            }
        }

        public DTO.ImageDTO Put(ImageDTO image)
        {
            return Convert.ImageConvert.Convert(model.Put(Convert.ImageConvert.Convert(image)));
        }

        public DTO.ImageDTO Delete(ImageDTO image)
        {
            return Convert.ImageConvert.Convert(model.Delete(Convert.ImageConvert.Convert(image)));
        }

    }
}
