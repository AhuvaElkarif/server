﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ImageModel
    {
        public List<image> Getimage()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.images.ToList();
            }
        }
        public image GetImageByImageId(int imageId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.images.FirstOrDefault(x => x.Id == imageId);
            }
        }

        public List<image> GetImageByAttractionId(int attractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.images.Where(x => x.AttractionId == attractionId).ToList();
            }
        }

        public image Post(image image)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                if(!db.images.Where(x=> x.AttractionId == image.AttractionId && x.Img == image.Img).Any()) 
                {
                    if (image.AttractionId == -1) image.AttractionId = null;
                    image = db.images.Add(image);
                    db.SaveChanges();
                    return image;
                }
                return null;
            }
        }
        public image Put(image image)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                image newImage = db.images.FirstOrDefault(x => x.Id == image.Id);
                newImage.Img = image.Img;
                newImage.AttractionId = image.AttractionId;
                db.SaveChanges();
                return image;
            }
        }
        public bool Delete(string image)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                image newimage = db.images.Remove(db.images.FirstOrDefault(x=>x.Img==image));
                db.SaveChanges();
                return true;
            }
        }
    }
}
