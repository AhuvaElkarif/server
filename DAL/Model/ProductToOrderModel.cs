using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ProductToOrderModel
    {
        public List<productToOrder> GetProductsToOrder()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.productToOrders.ToList();
            }
        }
        public productToOrder GetProductsByAttractionId(int attractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.productToOrders.FirstOrDefault(x => x.AttractionId == attractionId);
            }
        }
        public productToOrder GetProductsByOrderAttractionId(int orderAttractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.productToOrders.FirstOrDefault(x => x.OrderAttractionId == orderAttractionId);
            }
        }
        public productToOrder Post(productToOrder productToOrder)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                productToOrder = db.productToOrders.Add(productToOrder);
                db.SaveChanges();
                return productToOrder;
            }
        }
        public productToOrder Put(productToOrder productToOrder)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
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
        }
        public productToOrder Delete(productToOrder productToOrder)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                productToOrder newProductToOrder = db.productToOrders.Remove(productToOrder);
                db.SaveChanges();
                return productToOrder;
            }
        }
    }
}
