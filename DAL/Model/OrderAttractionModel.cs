using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public Dictionary<DateTime, int> GetDaysInMonth(int atractionId, int month, int year)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                var startDate = new DateTime(year,month,1);
                var lastDate = new DateTime(year, month, DateTime.DaysInMonth(year,month));
                if(startDate<DateTime.Now)
                    startDate = DateTime.Now;
                period period = db.periods.FirstOrDefault(x => 
                x.AttractionId == atractionId &&
                x.FromDate <= startDate &&
                x.TillDate >= lastDate);
                   
                //.g.Where();
                // כמה אטרקציות יכול להיות ביום
                Dictionary<DateTime, int> dic = new Dictionary<DateTime, int>();
                // לבדוק שהתאריכים עדיים תקפים
               // DateTime date = new DateTime(year, month, 1);
                //&&date<=endDate
                for (; startDate.Month == month; startDate=startDate.AddDays(1))
                {
                    //generalTime generalTimes = period.generalTimes.FirstOrDefault(x => x.DayInWeek == ((int)startDate.DayOfWeek));
                    //if (generalTimes != null)
                    //{
                    //    int manyDay = period.attraction.MaxParticipant * (int)(((generalTimes.EndTime.Value - generalTimes.StartTime.Value) * 60) / period.attraction.TimeDuration);
                    //    int countInDay = db.orderAttractions.Where(x => x.AttractionId == atractionId && x.OrderDate == startDate).ToList().Count();

                    //    dic.Add(startDate, manyDay - countInDay);
                    //}
            }

                return dic;
            }
            }

        public orderAttraction Post(orderAttraction orderAttraction)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                orderAttraction = db.orderAttractions.Add(orderAttraction);
                user u = db.users.FirstOrDefault(x => x.Id == orderAttraction.UserId);
                db.SaveChanges();
                SendMessage(u, orderAttraction);
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

        void SendMessage(user u, orderAttraction order)
        {
            try
            {
                MailMessage newMail = new MailMessage();
                // use the Gmail SMTP Host
                SmtpClient client = new SmtpClient();

                // Follow the RFS 5321 Email Standard
                newMail.From = new MailAddress("discoverisrael44@gmail.com");

                newMail.To.Add(new MailAddress("ahuvael02@gmail.com"));// declare the email subject

                newMail.Subject = "My First Email"; // use HTML for the email body

                newMail.IsBodyHtml = true;

                newMail.Body = "<h1> This is my first Templated Email in C# </h1>";

                
                // Port 465 for SSL communication
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                // enable SSL for encryption across channels
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("discoverisrael44@gmail.com", "discover44");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(newMail); // Send the constructed mail
                Console.WriteLine("Email Sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -" + ex);
            }
        }
    }
}
