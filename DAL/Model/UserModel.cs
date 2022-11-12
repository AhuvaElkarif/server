using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class UserModel
    {
        public List<user> GetUsers()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.users.Where(x => x.Active==true).ToList();
            }
        }
        public List<user> GetManagersUsers()
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.users.Where(x => x.Status == 2).ToList();
            }
        }
        public user GetUserByUserId(int userId)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.users.FirstOrDefault(x => x.Id == userId);
            }
        }
        public user GetUserByEmail(string email)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                if (IsEmail(email))
                    return db.users.FirstOrDefault(x => x.Email == email);
                return null;
            }
        }
        public bool IsEmail(string Email)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                return db.users.Any(x => x.Email == Email);
            }
        }
        public user Login(user user)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                user = db.users.FirstOrDefault(x => x.Password == user.Password && x.Email == user.Email);
                db.SaveChanges();
                return user;
            }
        }
        public user Post(user user)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                if (IsEmail(user.Email))
                    return null;
                user = db.users.Add(user);
                db.SaveChanges();
                return user;
            }
        }
        public user Put(user user)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                user newUser = db.users.FirstOrDefault(x => x.Id == user.Id);
                newUser.Name = user.Name;
                newUser.Password = user.Password;
                newUser.Phone = user.Phone;
                newUser.Status = user.Status;
                newUser.Email = user.Email;
                db.SaveChanges();
                return user;
            }
        }
        public user ChangePassword(user user)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                user newUser = db.users.FirstOrDefault(x => x.Email == user.Email);
                newUser.Password = user.Password;
                db.SaveChanges();
                return newUser;
            }
        }

        public List<user> ChangeUsersStatus(List<user> arr)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                List<user> a = db.users.Where(x => arr.Contains(x)).ToList();
                for (int i = 0; i < a.Count; i++)
                {
                    a[i].Active = !a[i].Active;
                }
                db.SaveChanges();
                return arr;
            }
        }
        public bool Delete(int user)
        {
            using (discoverIsraelEntities db = new discoverIsraelEntities())
            {
                user newUser = db.users.Remove(db.users.FirstOrDefault(x => x.Id == user));
                db.SaveChanges();
                return true;
            }
        }
    }
}
