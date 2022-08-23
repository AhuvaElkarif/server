using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class UserService
    {
        DAL.Model.UserModel model = new DAL.Model.UserModel();

        public List<DTO.UserDTO> GetUsers()
        {
            return Convert.UserConvert.Convert(model.GetUsers());
        }

        public DTO.UserDTO GetUserByUserId(int userId)
        {
            return Convert.UserConvert.Convert(model.GetUserByUserId(userId));
        }

        public DTO.UserDTO Post(UserDTO user)
        {

            return Convert.UserConvert.Convert(model.Post(Convert.UserConvert.Convert(user)));
        }

        public DTO.UserDTO Put(UserDTO user)
        {
            return Convert.UserConvert.Convert(model.Put(Convert.UserConvert.Convert(user)));
        }

        public bool Delete(int user)
        {
            return model.Delete(user);
        }
    }
}
