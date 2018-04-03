using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00_DataAccessLayer;
using _00_Entity;

namespace _00_BusinessLayer
{
    public class UserBusiness
    {
        UnitOfWork db;
        public UserBusiness()
        {
            db = new UnitOfWork();
        }
        public User Login(string email ,string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Lütfen email i doğru şekilde giriniz");
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Lütfen password doğru şekilde giriniz");

           User user = db.UserRepository.GetAll().Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (user!=null)
            {
                return user;
            }
            else { return null; }

        }
        public bool SignUp(User user) {
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new Exception("Lütfen epostanızı doğru şekilde giriniz");
            if (string.IsNullOrWhiteSpace(user.FullName))
                throw new Exception("Lütfen adınızı ve soyadınızı giriniz");
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new Exception("Lütfen şifrenizi doğru  giriniz");

            try
            {
                db.UserRepository.Add(user);
                return db.ApplyChanges();
            }
            catch (Exception ex)
            {
                throw;
                
            }

        }
        public List<User> GetAll()
        {
            return db.UserRepository.GetAll();
        }
        public User Get(int id)
        {
            return db.UserRepository.Get(id);
        }
        public bool Update(User user)
        {
            db.UserRepository.Update(user);
            return db.ApplyChanges();
        }
    }
}
 