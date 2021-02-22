
using BookYourMealAPI.Business.Repositories;
using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Business.Services
{
    public class LoginBll : ILoginBll
    {
        private readonly ILoginDA _loginDA;
        public LoginBll(ILoginDA loginDA)
        {
            _loginDA = loginDA;
        }
        public int AddUser(TblUserDetails tblUserDetails)
        {
            try
            {
                return _loginDA.AddUser(tblUserDetails);
            }
            catch(Exception e)
            {
                throw new AllException(e.Message);
            }
        }

        public void AddUserDetails(Guid userId, long mobile)
        {
            _loginDA.AddUserDetails(userId,mobile);
        }

        public UserDetails GetUserDetails(string email)
        {
            return _loginDA.GetUserDetails(email);
        }
        
    }
}