using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class CategoryService
    {

        DAL.Model.CategoryModel model = new DAL.Model.CategoryModel();

        public List<DTO.CategoryDTO> Get()
        {
            return Convert.CategoryConvert.Convert(model.Get());
        }

        public List<DTO.CategoryDTO> GetWaitingCategory()
        {
            return Convert.CategoryConvert.Convert(model.GetWaitingCategory());
        }

        public DTO.CategoryDTO GetCategoryByCategoryId(int categoryId)
        {
            return Convert.CategoryConvert.Convert(model.GetCategoryByCategoryId(categoryId));
        }

        public DTO.CategoryDTO Post(CategoryDTO category)
        {
            return Convert.CategoryConvert.Convert(model.Post(Convert.CategoryConvert.Convert(category)));
        }
        public DTO.CategoryDTO ChangeStatus(CategoryDTO category, byte[] data)
        {
            ImageService img = new ImageService();
            if(data != null)
            img.uploadImgBytes(category.Img, data);
            return Convert.CategoryConvert.Convert(model.ChangeStatus(Convert.CategoryConvert.Convert(category)));
        }
        public DTO.CategoryDTO Put(CategoryDTO category)
        {
            return Convert.CategoryConvert.Convert(model.Put(Convert.CategoryConvert.Convert(category)));
        }

        public bool Delete(int id)
        {
            return model.Delete(id);
        }

    }
}
