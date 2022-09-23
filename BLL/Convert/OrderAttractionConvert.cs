using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class OrderAttractionConvert
    {
        public static DTO.OrderAttractionDTO Convert(DAL.orderAttraction obj)
        {
            if (obj == null)
                return null;
            return new DTO.OrderAttractionDTO()
            {
                Id = obj.Id,
                OrderDate = obj.OrderDate,
                UserId = obj.UserId,
                GlobalPrice = obj.GlobalPrice,
                AttractionId = obj.AttractionId
            };
        }

        public static DAL.orderAttraction Convert(DTO.OrderAttractionDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.orderAttraction()
            {
                Id = obj.Id,
                OrderDate = obj.OrderDate,
                UserId = obj.UserId,
                AttractionId = obj.AttractionId,
                GlobalPrice = obj.GlobalPrice
            };
        }

        public static List<DAL.orderAttraction> Convert(List<DTO.OrderAttractionDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.OrderAttractionDTO> Convert(List<DAL.orderAttraction> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
