using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Business.Repositories
{
    public interface ILoginBll
    {
        int AddUser(TblUserDetails tblUserDetails);
        UserDetails GetUserDetails(string email);

        void AddUserDetails(Guid userId, long mobile);
       // int CheckDetails(string email);
    }
}
