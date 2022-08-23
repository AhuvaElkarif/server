using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class ProductToOrderConvert
    {
        public static DTO.ProductToOrderDTO Convert(DAL.productToOrder obj)
        {
            if (obj == null)
                return null;
            return new DTO.ProductToOrderDTO()
            {
                Id = obj.Id,
                Amount = obj.Amount,
                AttractionId = obj.AttractionId,
                FromHour = obj.FromHour,
                TillHour = obj.TillHour,
                Status = obj.Status,
                OrderAttractionId = obj.OrderAttractionId
            };
        }

        public static DAL.productToOrder Convert(DTO.ProductToOrderDTO obj)
        {
            if (obj == null)
                return null;
            return new DAL.productToOrder()
            {
                Id = obj.Id,
                Amount = obj.Amount,
                AttractionId = obj.AttractionId,
                FromHour = obj.FromHour,
                TillHour = obj.TillHour,
                Status = obj.Status,
                OrderAttractionId = obj.OrderAttractionId
            };
        }

        public static List<DAL.productToOrder> Convert(List<DTO.ProductToOrderDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.ProductToOrderDTO> Convert(List<DAL.productToOrder> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
