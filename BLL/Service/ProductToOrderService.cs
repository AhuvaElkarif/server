using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProductToOrderService
    {
        DAL.Model.ProductToOrderModel model = new DAL.Model.ProductToOrderModel();

        public List<DTO.ProductToOrderDTO> GetProductToOrders()
        {
            return Convert.ProductToOrderConvert.Convert(model.GetProductsToOrder());
        }

        public DTO.ProductToOrderDTO GetProductsByOrderAttractionId(int orderId)
        {
            return Convert.ProductToOrderConvert.Convert(model.GetProductsByOrderAttractionId(orderId));
        }

        public DTO.ProductToOrderDTO GetProductsByAttractionId(int attractionId)
        {
            return Convert.ProductToOrderConvert.Convert(model.GetProductsByAttractionId(attractionId));
        }

        public DTO.ProductToOrderDTO Post(ProductToOrderDTO productToOrder)
        {
            return Convert.ProductToOrderConvert.Convert(model.Post(Convert.ProductToOrderConvert.Convert(productToOrder)));
        }

        public DTO.ProductToOrderDTO Put(ProductToOrderDTO productToOrder)
        {
            return Convert.ProductToOrderConvert.Convert(model.Put(Convert.ProductToOrderConvert.Convert(productToOrder)));
        }

        public DTO.ProductToOrderDTO Delete(ProductToOrderDTO productToOrder)
        {
            return Convert.ProductToOrderConvert.Convert(model.Delete(Convert.ProductToOrderConvert.Convert(productToOrder)));
        }
    }
}
