using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class UserModel
    {
        discoverIsraelEntities db = new discoverIsraelEntities();
        public List<user> GetUsers()
        {
            return db.users.ToList();
        }
        public user GetUserByUserId(int userId)
        {
            return db.users.FirstOrDefault(x => x.Id == userId);
        }
        public bool IsEmail(string Email)
        {
            return db.users.Any(x => x.Email == Email);
               
        }
            public user Post(user user)
        {
            if (IsEmail(user.Email))
                return null;
            user = db.users.Add(user);
            db.SaveChanges();
            return user;
        }
        public user Put(user user)
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
        public bool Delete(int user)
        {
            user newUser = db.users.Remove(db.users.FirstOrDefault(x=>x.Id==user));
            db.SaveChanges();
            return true;

        }
    }
}
