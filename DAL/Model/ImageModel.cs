using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ImageModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();
        public List<image> Getimage()
        {
            return db.images.ToList();
        }
        public image GetImageByImageId(int imageId)
        {
            return db.images.FirstOrDefault(x => x.Id == imageId);
        }

        public List<image> GetImageByAttractionId(int attractionId)
        {
            return db.images.Where(x => x.AttractionId == attractionId).ToList();
        }

        public image Post(image image)
        {
            image = db.images.Add(image);
            db.SaveChanges();
            return image;
        }
        public image Put(image image)
        {
            image newImage = db.images.FirstOrDefault(x => x.Id == image.Id);
            newImage.Img = image.Img;
            db.SaveChanges();
            return image;

        }
        public image Delete(image image)
        {
            image newimage = db.images.Remove(image);
            db.SaveChanges();
            return image;
        }
    }
}
