using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AttractionService
    {
        DAL.Model.AttractionModel model = new DAL.Model.AttractionModel();

        public List<DTO.AttractionDTO> GetAttractions()
        {
            return Convert.AttractionConvert.Convert(model.GetAttractions());
        }

        public DTO.AttractionDTO GetAttractionByAttractionId(int attractionId)
        {
           return Convert.AttractionConvert.Convert(model.GetAttractionByAttractionId(attractionId));
        }

        public List<DTO.AttractionDTO> GetAttractionsByUserId(int id)
        {
            return Convert.AttractionConvert.Convert(model.GetAttractionsByUserId(id));
        }

        //public List<DateTime> getrelevantdatesbyamount(int qty, int month)
        //{
        //    List<attraction> list = model.GetAttractions();
        //    list.Where(x => x.generalTimes.Where(y => (y.EndTime - y.StartTime) / x.TimeDuration);

        //}
        public List<DTO.AttractionDTO> GetAttractionsByCategoryId(int categoryId)
        {
            return Convert.AttractionConvert.Convert(model.GetAttractionsByCategoryId(categoryId));
        }

        public DTO.AttractionDTO Post(AttractionDTO attraction)
        {
            return Convert.AttractionConvert.Convert(model.Post(Convert.AttractionConvert.Convert(attraction)));
        }

        public DTO.AttractionDTO Put(AttractionDTO attraction)
        {
           return Convert.AttractionConvert.Convert(model.Put(Convert.AttractionConvert.Convert(attraction)));
        }
        
             public DTO.AttractionDTO ChangeAttractionAvailable(int attractionId)
        {
            return Convert.AttractionConvert.Convert(model.ChangeAttractionAvailable(attractionId));
        }
        public DTO.AttractionDTO ChangeAttractionStatus(int attractionId)
        {
            return Convert.AttractionConvert.Convert(model.ChangeAttractionStatus(attractionId));
        }
        public DTO.AttractionDTO Delete(AttractionDTO attraction)
        {
            return Convert.AttractionConvert.Convert(model.Delete(Convert.AttractionConvert.Convert(attraction)));
        }

    }
}
