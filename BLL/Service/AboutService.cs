using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AboutService
    {
        DAL.Model.AboutModel model = new DAL.Model.AboutModel();

        public List<DTO.AboutDTO> Get()
        {
            return Convert.AboutConvert.Convert(model.Get());
        }


        public DTO.AboutDTO Post(AboutDTO about)
        {
            return Convert.AboutConvert.Convert(model.Post(Convert.AboutConvert.Convert(about)));
        }
      
        public DTO.AboutDTO Put(AboutDTO about)
        {
            return Convert.AboutConvert.Convert(model.Put(Convert.AboutConvert.Convert(about)));
        }

        public bool Delete(int id)
        {
            return model.Delete(id);
        }

    }
}

