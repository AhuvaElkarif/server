using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class OrderAttractionModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();
        public List<orderAttraction> GetOrders()
        {
            return db.orderAttractions.ToList();
        }
        public orderAttraction GetOrdersByOrderAttractionId(int orderAttractionId)
        {
            return db.orderAttractions.FirstOrDefault(x => x.Id == orderAttractionId);
        }
        public orderAttraction GetOrdersByUserId(int userId)
        {
            return db.orderAttractions.FirstOrDefault(x => x.UserId == userId);
        }

        public orderAttraction Post(orderAttraction orderAttraction)
        {
            orderAttraction = db.orderAttractions.Add(orderAttraction);
            db.SaveChanges();
            return orderAttraction;
        }
        public orderAttraction Put(orderAttraction orderAttraction)
        {
            orderAttraction newOrderAttraction = db.orderAttractions.FirstOrDefault(x => x.Id == orderAttraction.Id);
            newOrderAttraction.OrderDate = orderAttraction.OrderDate;
            newOrderAttraction.UserId = orderAttraction.UserId;
            newOrderAttraction.GlobalPrice = orderAttraction.GlobalPrice;
            db.SaveChanges();
            return orderAttraction;

        }
        public orderAttraction Delete(orderAttraction orderAttraction)
        {
            orderAttraction newOrderAttraction = db.orderAttractions.Remove(orderAttraction);
            db.SaveChanges();
            return orderAttraction;

        }
    }
}
