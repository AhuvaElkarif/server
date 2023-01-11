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
                return db.orderAttractions.Include("attraction").Include("attraction.images").Include("attraction.periods").Include("attraction.opinions").Include("attraction.category").Include("user").Where(x => x.Status == true).ToList();
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
                return db.orderAttractions.Include("attraction").Include("attraction.images").Include("attraction.periods").Include("attraction.opinions").Include("attraction.category").Include("user").Where(x => x.attraction.ManagerId == managerId && x.Status == true).ToList();
            }
        }
        public List<orderAttraction> GetOrdersByUserId(int userId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.orderAttractions.Include("attraction").Include("attraction.images").Include("attraction.periods").Include("attraction.opinions").Include("attraction.category").Where(x => x.UserId == userId && x.Status == true).ToList();
            }
        }
        public List<EventsInCalender> GetDaysInMonth(int atractionId, int month, int year, int amount)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                var start = new DateTime(year, month, 1);
                var startDate = new DateTime(year, month, 1);
                List<EventsInCalender> daysInMonth = new List<EventsInCalender>();
                var lastDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                // אתחול תאריך ההתחלה לתאריך הנוכחי
                if (startDate < DateTime.Now)
                    startDate = DateTime.Now;

                // מציאת כל התקופות המתאימות לחודש והשנה
                List<period> periods = db.periods.Where(x =>
                                       x.AttractionId == atractionId && x.IsOpen == true &&
                                       (x.FromDate <= startDate
                                       || (x.FromDate.Year == startDate.Year
                                       && x.FromDate.Month == startDate.Month))
                                       && (x.TillDate >= lastDate
                                       || (x.TillDate.Year == startDate.Year
                                       && x.TillDate.Month == startDate.Month))).ToList();
                // במידה ולא נמצאו כלל תקופות
                if (periods == null)
                {
                    for (var s = start; s.Month == month; s = s.AddDays(1))
                    {
                        daysInMonth.Add(new EventsInCalender() { start = start.Date, title = "סגור", backgroundColor = "red" });
                    }
                    return daysInMonth;
                }

                // מעבר על כל הימים שעברו כבר בחודש הנוכחי והצגת הודעה מתאימה
                for (; start.Date != startDate.Date; start = start.AddDays(1))
                {
                    daysInMonth.Add(new EventsInCalender() { start = start.Date, title = "סגור", backgroundColor = "red" });
                }
                // מיון הרשימה לפי תאריכי החודש
                periods = periods.OrderBy(p => p.FromDate).ToList();
                for (int i = 0; i < periods.Count(); i++)
                {
                    period period = periods[i];
                    for (; startDate.Month == month; startDate = startDate.AddDays(1))
                    {
                        if (startDate >= period.FromDate && startDate <= period.TillDate)
                        {
                            generalTime g = period.generalTimes.FirstOrDefault(x => x.DayInWeek == ((int)startDate.DayOfWeek));
                            if (g != null)
                            {
                                TimeSpan diff = (TimeSpan)(g.EndTime - g.StartTime);
                                var manyDay = period.attraction.MaxParticipant * ((int)diff.TotalMinutes / period.attraction.TimeDuration);//( (int)g.EndTime.Value.Hours - (int)g.StartTime.Value.Hours) * 60 / period.attraction.TimeDuration);
                                int countInDay = db.orderAttractions.Where(x => x.AttractionId == atractionId && x.OrderDate == startDate && x.Status==true).ToList().Count();
                                if ((int)manyDay - countInDay >= amount && countInDay + amount >= period.attraction.MinParticipant)
                                    daysInMonth.Add(new EventsInCalender() { start = startDate.Date, title = "יש כרטיסים", backgroundColor = "green" });
                                else
                                    daysInMonth.Add(new EventsInCalender() { start = startDate.Date, title = "כרטיסים אזלו", backgroundColor = "red" });
                            }
                            else
                                daysInMonth.Add(new EventsInCalender() { start = startDate.Date, title = "סגור", backgroundColor = "red" });
                        }
                        else
                        {
                            if (i + 1 < periods.Count())
                                for (; startDate.Month == month && startDate <= periods[i + 1].FromDate; startDate = startDate.AddDays(1))
                                    daysInMonth.Add(new EventsInCalender() { start = startDate.Date, title = "סגור", backgroundColor = "red" });

                            break;
                        }
                    }
                }

                // מעבר על כל הימים שנשארו בחודש
                for (; startDate.Date != lastDate.Date.AddDays(1); startDate = startDate.AddDays(1))
                {
                    daysInMonth.Add(new EventsInCalender() { start = startDate.Date, title = "סגור", backgroundColor = "red" });
                }
                return daysInMonth;
            }
        }

        public List<EventsInCalender> GetTimesInDay(DateTime date, int attractionId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                var day = date.DayOfWeek;
                var period = db.periods.FirstOrDefault(x => x.Id == attractionId && x.FromDate <= date && x.TillDate >= date);
                var timeDuration = period.attraction.TimeDuration;
                var times = db.generalTimes.FirstOrDefault(x => x.PeriodId == period.Id && x.DayInWeek == (int)day);
                List<EventsInCalender> timesInDays = new List<EventsInCalender>();

                if (times == null)
                    return null;
                TimeSpan diff = (TimeSpan)(times.EndTime - times.StartTime);
                for (TimeSpan start = times.StartTime.Value; TimeSpan.Compare(times.EndTime.Value, start) > 0; start = start.Add(TimeSpan.FromMinutes((double)timeDuration)))
                {
                    var manyTime = period.attraction.MaxParticipant * ((int)diff.TotalMinutes / timeDuration);//( (int)g.EndTime.Value.Hours - (int)g.StartTime.Value.Hours) * 60 / period.attraction.TimeDuration);
                    int countInTime = db.orderAttractions.Where(x => x.AttractionId == period.AttractionId && x.OrderDate == date && x.Status==true).GroupBy(x => x.StartTime).ToList().Count();
                    //  if ((int)manyTime - countInTime > 0)
                    //    timesInDays.Add(new EventsInCalender() { start = startDate, title = "יש כרטיסים", backgroundColor = "green" });
                }

                return timesInDays;
            }
        }
        public int addTempUser(user user)
        {
            UserModel u = new UserModel();
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                if (u.IsEmail(user.Email))
                    user = db.users.FirstOrDefault(x => x.Email == user.Email);
                else
                    user = db.users.Add(user);
                db.SaveChanges();
                return user.Id;
            }

        }
        public orderAttraction Post(orderAttraction orderAttraction, user user)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                if (orderAttraction.UserId == -1)
                     orderAttraction.UserId = addTempUser(user);
                orderAttraction = db.orderAttractions.Add(orderAttraction);
                user u = db.users.FirstOrDefault(x => x.Id == orderAttraction.UserId);
                orderAttraction.user = u;
                db.SaveChanges();
                string b = "<h1> הזמנתך בוצעה בהצלחה! </h1>";
                b += "<h4> פרטי הזמנה: </h4>";
                b += "<p> תאריך: " + orderAttraction.OrderDate + " זמן התחלה האטרקציה " + orderAttraction.StartTime
                    + " כמות משתתפים: " + orderAttraction.Amount + " על סך: " + orderAttraction.GlobalPrice + "</p>";
                SendMessage(u, orderAttraction, "ההזמנה התבצעה בהצלחה!", b);
                return orderAttraction;
            }
        }
        public bool ChangeStatus(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                orderAttraction o = db.orderAttractions.FirstOrDefault(x => x.Id == id);
                o.Status = !o.Status;
                if (o.Status == false)
                {
                    SendMessage(o.user, o, "<h1>ביטול הזמנה</h1>", "הזמנתך בוטלה בהצלחה.");
                }
                db.SaveChanges();
                return true;
            }
        }
        public bool ChangeApproval(int id)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                orderAttraction o = db.orderAttractions.FirstOrDefault(x => x.Id == id);
                o.IsApproval = !o.IsApproval;
                if (o.IsApproval == false)
                {
                    SendMessage(o.user, o, "<h1> תשלום עבור הזמנה שבוטלה</h1>", "הזמנתך בוטלה ונעשה זיכוי כספי עבור התשלום שביצעת.");
                }
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
                newOrderAttraction.IsApproval = orderAttraction.IsApproval;
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

        public void SendMessage(user u, orderAttraction order, string sub, string body)
        {
            try
            {
                MailMessage newMail = new MailMessage();
                // use the Gmail SMTP Host
                SmtpClient client = new SmtpClient();
                // Follow the RFS 5321 Email Standard
                newMail.From = new MailAddress("discoverisrael44@gmail.com");
                newMail.To.Add(new MailAddress(u.Email));// declare the email subject
                newMail.Subject = sub; // use HTML for the email body
                newMail.IsBodyHtml = true;
                newMail.Body = body;
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
