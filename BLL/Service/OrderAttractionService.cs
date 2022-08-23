using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class OrderAttractionService
    {
        DAL.Model.OrderAttractionModel model = new DAL.Model.OrderAttractionModel();

        public List<DTO.OrderAttractionDTO> GetOrders()
        {
            return Convert.OrderAttractionConvert.Convert(model.GetOrders());
        }
        public DTO.OrderAttractionDTO GetOrdersByOrderAttractionId(int orderAttractionId)
        {
            return Convert.OrderAttractionConvert.Convert(model.GetOrdersByOrderAttractionId(orderAttractionId));
        }
        public DTO.OrderAttractionDTO GetOrdersByUserId(int userId)
        {
            return Convert.OrderAttractionConvert.Convert(model.GetOrdersByUserId(userId));
        }

        public DTO.OrderAttractionDTO Post(OrderAttractionDTO orderAttraction)
        {
            return Convert.OrderAttractionConvert.Convert(model.Post(Convert.OrderAttractionConvert.Convert(orderAttraction)));
        }

        public DTO.OrderAttractionDTO Put(OrderAttractionDTO orderAttraction)
        {
            return Convert.OrderAttractionConvert.Convert(model.Put(Convert.OrderAttractionConvert.Convert(orderAttraction)));
        }

        public DTO.OrderAttractionDTO Delete(OrderAttractionDTO orderAttraction)
        {
            return Convert.OrderAttractionConvert.Convert(model.Delete(Convert.OrderAttractionConvert.Convert(orderAttraction)));
        }
    }
}
