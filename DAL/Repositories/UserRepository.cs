using Microsoft.EntityFrameworkCore;
using MyBookMarks.DAL.interfaces;
using MyBookMarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyBookMarksDbContext _Dbase;

        public UserRepository(MyBookMarksDbContext ctx)
        {
            _Dbase = ctx;
        }

        public void Add(User user)
        {
            try
            {
                _Dbase.Users.Add(user);
                _Dbase.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Delete(long userId)
        {
            _Dbase.Users.Remove(Get(userId));
            _Dbase.SaveChanges();
        }

        public User Get(long userId)
        {
            return _Dbase.Users
                .FirstOrDefault(u => u.Id == userId);
        }

        public IQueryable<User> GetAll()
        {
            return _Dbase.Users;
        }

        public Task<User> GetByEmail(string userEmail)
        {
            return _Dbase.Users
                .FirstOrDefaultAsync(u => u.Email == userEmail);
        }

        public void Update(User user)
        {
            _Dbase.Users.Update(user);
            _Dbase.SaveChanges();
        }
    }
}
