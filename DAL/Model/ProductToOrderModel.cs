using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ProductToOrderModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();
        public List<productToOrder> GetProductsToOrder()
        {
            return db.productToOrders.ToList();
        }
        public productToOrder GetProductsByAttractionId(int attractionId)
        {
            return db.productToOrders.FirstOrDefault(x => x.AttractionId == attractionId);
        }
        public productToOrder GetProductsByOrderAttractionId(int orderAttractionId)
        {
            return db.productToOrders.FirstOrDefault(x => x.OrderAttractionId == orderAttractionId);
        }
        public productToOrder Post(productToOrder productToOrder)
        {
            productToOrder = db.productToOrders.Add(productToOrder);
            db.SaveChanges();
            return productToOrder;
        }
        public productToOrder Put(productToOrder productToOrder)
        {
            productToOrder newProductToOrder = db.productToOrders.FirstOrDefault(x => x.Id == productToOrder.Id);
            newProductToOrder.Amount = productToOrder.Amount;
            newProductToOrder.AttractionId = productToOrder.AttractionId;
            newProductToOrder.FromHour = productToOrder.FromHour;
            newProductToOrder.TillHour = productToOrder.TillHour;
            newProductToOrder.Status = productToOrder.Status;
            newProductToOrder.OrderAttractionId = productToOrder.OrderAttractionId;
            db.SaveChanges();
            return productToOrder;

        }
        public productToOrder Delete(productToOrder productToOrder)
        {
            productToOrder newProductToOrder = db.productToOrders.Remove(productToOrder);
            db.SaveChanges();
            return productToOrder;

        }
    }
}
