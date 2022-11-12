using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class OrderAttractionModel
    {
        public List<orderAttraction> GetOrders()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.orderAttractions.Include("attraction").Include("attraction.images").Include("attraction.periods").Include("attraction.opinions").Include("attraction.category").Where(x => x.Status == true).ToList();
            }
        }
        public orderAttraction GetOrdersByOrderAttractionId(int orderAttractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.orderAttractions.Include("attraction").Include("attraction.images").Include("attraction.periods").Include("attraction.opinions").Include("attraction.category").FirstOrDefault(x => x.Id == orderAttractionId && x.Status == true);
            }
        }
        public List<orderAttraction> GetOrdersByManagerId(int managerId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.orderAttractions.Include("attraction").Include("attraction.images").Include("attraction.periods").Include("attraction.opinions").Include("attraction.category").Where(x => x.attraction.ManagerId == managerId && x.Status == true).ToList();
            }
        }
        public List<orderAttraction> GetOrdersByUserId(int userId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.orderAttractions.Include("attraction").Include("attraction.images").Include("attraction.periods").Include("attraction.opinions").Include("attraction.category").Where(x => x.UserId == userId && x.Status == true).ToList();
            }
        }
        public Dictionary<DateTime, int> GetOrdersUserId(int atractionId, int month, int year)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                var startDate = new DateTime(year,month,1);
                var lastDate = new DateTime(year, month, 30);

                period period = db.periods.FirstOrDefault(x => 
                x.Id == atractionId &&
                x.FromDate <= startDate &&
                x.TillDate >= lastDate);
                   
                //.g.Where();
                // כמה אטרקציות יכול להיות ביום
                Dictionary<DateTime, int> dic = new Dictionary<DateTime, int>();
                // לבדוק שהתאריכים עדיים תקפים
               // DateTime date = new DateTime(year, month, 1);
                //&&date<=endDate
                for (; startDate.Month == month; startDate.AddDays(1))
                {
                    generalTime generalTimes = period.generalTimes.FirstOrDefault(x => x.DayInWeek == ((int)startDate.DayOfWeek));
                    if (generalTimes != null)
                    {
                        int manyDay = period.attraction.MaxParticipant * (int)(((generalTimes.EndTime - generalTimes.StartTime) * 60) / period.attraction.TimeDuration);
                        int countInDay = db.orderAttractions.Where(x => x.AttractionId == atractionId && x.OrderDate == startDate).ToList().Count();

                        dic.Add(startDate, manyDay - countInDay);
                    }
            }

                return dic;
            }
            }

        public orderAttraction Post(orderAttraction orderAttraction)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                orderAttraction = db.orderAttractions.Add(orderAttraction);
                db.SaveChanges();
                return orderAttraction;
            }
        }
        public bool ChangeStatus(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                orderAttraction o = db.orderAttractions.FirstOrDefault(x => x.Id == id);
                o.Status = !o.Status;
                db.SaveChanges();
                return true;
            }
        }
        public orderAttraction Put(orderAttraction orderAttraction)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                orderAttraction newOrderAttraction = db.orderAttractions.FirstOrDefault(x => x.Id == orderAttraction.Id);
                newOrderAttraction.OrderDate = orderAttraction.OrderDate;
                newOrderAttraction.UserId = orderAttraction.UserId;
                newOrderAttraction.GlobalPrice = orderAttraction.GlobalPrice;
                newOrderAttraction.Amount = orderAttraction.Amount;
                newOrderAttraction.Status = orderAttraction.Status;
                db.SaveChanges();
                return orderAttraction;
            }
        }
        public orderAttraction Delete(orderAttraction orderAttraction)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                orderAttraction newOrderAttraction = db.orderAttractions.Remove(orderAttraction);
                db.SaveChanges();
                return orderAttraction;
            }
        }
    }
}
