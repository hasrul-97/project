using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.DataAccess.Services
{
    public class LoginDA : ILoginDA
    {
        private readonly Orchard8Context _bookYourMealFinalContext;
        public LoginDA(Orchard8Context bookYourMealFinalContext)
        {
            _bookYourMealFinalContext = bookYourMealFinalContext;
        }
        public int AddUser(TblUserDetails tblUserDetails)
        {
            int flag = 1;
            bool checkEmail = false;
            DateTime dateTime = DateTime.Now;
            tblUserDetails.UserId = Guid.NewGuid();
            tblUserDetails.SignupDtstamp = dateTime;
            tblUserDetails.RoleId = 5;
            List<TblUserDetails> userDetails = _bookYourMealFinalContext.TblUserDetails.ToList();
            foreach (var item in userDetails)
            {
                if (item.Email == tblUserDetails.Email)
                {
                    checkEmail = true;
                    break;
                }
            }
            if (!checkEmail)
            {
                _bookYourMealFinalContext.TblUserDetails.Add(tblUserDetails);
                _bookYourMealFinalContext.SaveChanges();
                flag = 1;
            }
            else
            {
                flag = 0;
            }
            return flag;
        }

        public void AddUserDetails(Guid userId, long mobile)
        {
            Console.WriteLine("HEllo");
        }

        //public int CheckDetails(string email)
        //{
        //    int flag = 1;
        //    string address = "";
        //    List<TblUserDetails> userDetails = _bookYourMealFinalContext.TblUserDetails.ToList();
        //    foreach (var items in userDetails)
        //    {
        //        if (items.Email == email)
        //        {
        //            address = items.UserLocation;
        //            break;
        //        }
        //    }
        //    if (address == null)
        //    {
        //        flag = 1;
        //    }
        //    else
        //    {
        //        flag = 0;
        //    }
        //    return flag;
        //}
        //public void AddUserDetails(TblUserDetails tblUserDetails)
        //{
        //    Guid userId;
        //    List<TblUserDetails> userDetails = _bookYourMealFinalContext.TblUserDetails.ToList();
        //    foreach (var items in userDetails)
        //    {
        //        if (items.Email == tblUserDetails.Email)
        //        {
        //            userId = items.UserId;
        //            break;
        //        }
        //        else
        //        {
        //            _bookYourMealFinalContext.TblUserDetails.Add(tblUserDetails);
        //            _bookYourMealFinalContext.SaveChanges();
        //        }
        //    }

        //}
        public string GetRoleName(string email)
        {
            try
            {
                //TblRole tblRole = new TblRole();
                //TblUserDetails userDetails = _bookYourMealFinalContext.TblUserDetails.Find(userId);
                //if (userDetails == null)
                //{
                //    throw new CustomerNotFoundException("No user Found");
                //}
                //else
                //{
                //    var roleName = from r in _bookYourMealFinalContext.TblRole
                //                   join u in _bookYourMealFinalContext.TblUserDetails
                //                   on r.RoleId equals u.RoleId
                //                   select new { r.RoleName };
                //    foreach (var item in roleName)
                //    {
                //        tblRole.RoleName = item.RoleName;
                //    }
                //    return tblRole.RoleName;
                //}

                List<TblUserDetails> userDetails = _bookYourMealFinalContext.TblUserDetails.ToList();
                string roleName = "";
                int roleId;
                foreach (var items in userDetails)
                {
                    if (items.Email == email)
                    {
                        roleId = items.RoleId;
                        //roleName =from r in _bookYourMealFinalContext.TblRole join u in _bookYourMealFinalContext.TblUserDetails on r.RoleId equals u.RoleId select new { r.RoleName };
                        // roleId = _bookYourMealFinalContext.TblUserDetails.First(x => x.UserId== userId).RoleId;
                        roleName = _bookYourMealFinalContext.TblRole.First(x => x.RoleId == roleId).RoleName;
                        break;
                    }



                }

                return roleName;




            }
            catch (CustomerNotFoundException e)
            {

                throw e;
            }
            catch (SqlException e)
            {

                throw e;
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public UserDetails GetUserDetails(string email)
        {
            List<TblUserDetails> userDetails = _bookYourMealFinalContext.TblUserDetails.ToList();
            UserDetails userDetails1 = new UserDetails();
            foreach(var item in userDetails)
            {
                if(item.Email.Equals(email))
                {
                    int roleId = item.RoleId;
                    userDetails1.UserId = item.UserId;
                    userDetails1.RoleName = _bookYourMealFinalContext.TblRole.First(x => x.RoleId == roleId).RoleName;
                    userDetails1.Name = item.Name;
                    userDetails1.UserMobile = item.UserMobile;
                }
            }

            return userDetails1;

        }
    }

}
