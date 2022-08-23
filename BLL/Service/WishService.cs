using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class WishService
    {
        DAL.Model.WishModel model = new DAL.Model.WishModel();

        public List<DTO.WishDTO> GetWishes()
        {
            return Convert.WishConvert.Convert(model.GetWishes());
        }

        public List<DTO.WishDTO> GetWishesByUserId(int userId)
        {
            return Convert.WishConvert.Convert(model.GetWishesByUserId(userId));
        }

        public DTO.WishDTO Post(DTO.WishDTO wish)
        {
            return Convert.WishConvert.Convert(model.Post(Convert.WishConvert.Convert(wish)));
        }

        public DTO.WishDTO Put(DTO.WishDTO wish)
        {
            return Convert.WishConvert.Convert(model.Put(Convert.WishConvert.Convert(wish)));
        }

        public bool Delete(int user)
        {
            return model.Delete(user);
        }
    }
}
