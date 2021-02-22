using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.DataAccess.Services
{
    public class AdminDA : IAdminDA
    {
        private readonly Orchard8Context _DbContext;
        public AdminDA(Orchard8Context dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<bool> DisableRestaurent(Guid userId)
        {
            try
            {
                TblUserDetails tblUserDetails = _DbContext.TblUserDetails.Find(userId);
                if (tblUserDetails == null)
                {
                    throw new CustomerNotFoundException("Sorry,No Users Found ");
                }
                else
                {
                    var tblRoles = _DbContext.TblRole.Where(i => i.RoleName == "Customer").Select(i => i.RoleId);

                    TblRole tblRole = await _DbContext.TblRole.FindAsync(tblUserDetails.RoleId);
                    if (tblRole.RoleName == "RestaurantOwner")
                    {
                        if (tblUserDetails.ActiveUserId == 1)
                        {
                            foreach (var item in tblRoles)
                            {
                                tblUserDetails.RoleId = item;
                            }
                            tblUserDetails.ActiveUserId = 2;

                            if (await _DbContext.SaveChangesAsync() == 1)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            throw new AlreadyDisabledRestaurantException("Restaurant is Already Disabled");
                        }
                    }
                    else
                    {
                        throw new RestaurantNotFoundException("Restaurant not found");
                    }
              
                }
            }
            catch (CustomerNotFoundException e)
            {
                throw new AllException(e.Message);
            }
            catch (AlreadyDisabledRestaurantException e)
            {
                throw new AllException(e.Message);
            }
            catch (RestaurantNotFoundException e)
            {
                throw new AllException(e.Message);
            }
            catch (SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
        }
        [ExcludeFromCodeCoverage]
        public async Task<bool> EnableRestaurent(Guid userId)
        {
            try
            {
                TblUserDetails tblUserDetails = _DbContext.TblUserDetails.Find(userId);
                if (tblUserDetails == null)
                {
                    throw new CustomerNotFoundException("Sorry,No Users Found ");
                }
                else
                {
                    var tblRoles = _DbContext.TblRole.Where(i => i.RoleName == "RestaurantOwner").Select(i => i.RoleId);
                    TblRole tblRole =  await _DbContext.TblRole.FindAsync(tblUserDetails.RoleId);
                    if (tblRole.RoleName == "Customer")
                    {
                        if (tblUserDetails.ActiveUserId == 2)
                        {
                            foreach (var item in tblRoles)
                            {
                                tblUserDetails.RoleId = item;
                            }
                            tblUserDetails.ActiveUserId = 1;

                            if (await _DbContext.SaveChangesAsync() == 1)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            throw new AlreadyDisabledRestaurantException("Restaurant is Already Enabled");
                        }
                    }
                    else
                    {
                        throw new RestaurantNotFoundException("Restaurant not found");
                    }
                }
            }
            catch (CustomerNotFoundException e)
            {
                throw new AllException(e.Message);
            }
            catch (AlreadyDisabledRestaurantException e)
            {
                throw new AllException(e.Message);
            }
            catch (RestaurantNotFoundException e)
            {
                throw new AllException(e.Message);
            }
            catch (SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
        }
        public async Task<bool> DisableCustomer(Guid userId)
        {
            try
            {
                TblUserDetails tblUserDetails = await _DbContext.TblUserDetails.FindAsync(userId);
                if (tblUserDetails == null || tblUserDetails.RoleId != 2)
                {
                    throw new CustomerNotFoundException("Sorry,No Users Found ");
                }
                else
                {
                    if (tblUserDetails.ActiveUserId == 1)
                    {
                        tblUserDetails.ActiveUserId = 2;
                        if (await _DbContext.SaveChangesAsync() == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        throw new AlreadyDisabledCustomerException("Customer is Already Disabled");
                    }
                }
            }
            catch (CustomerNotFoundException e)
            {
                throw new AllException(e.Message);
            }
            catch (AlreadyDisabledRestaurantException e )
            {
                throw new AllException(e.Message);
            }
            catch (SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
     
        }
        [ExcludeFromCodeCoverage]
        public async Task<bool> ApproveRestaurent(int approveId)
        {
            try
            {
                TblApprove tblApproves = await _DbContext.TblApprove.FindAsync(approveId);
                if (tblApproves == null)
                {
                    throw new NoRestaurantRequestFound("No Restaurant Request Found");
                }
                else
                {
                    if (tblApproves.ApprovalStatusId == 2)
                    {
                        tblApproves.ApprovalStatusId = 1;
                         await _DbContext.SaveChangesAsync();

                        TblUserDetails tblUserDetails = await _DbContext.TblUserDetails.FindAsync(tblApproves.UserId);
                        var tblRoles = _DbContext.TblRole.Where(i => i.RoleName == "RestaurantOwner").Select(i => i.RoleId);
                        foreach (var item in tblRoles)
                        {
                            tblUserDetails.RoleId = item;
                        }
                        
                        //_DbContext.SaveChanges();
                        TblRestaurantDetails tblRestaurantDetails = new TblRestaurantDetails();
                        tblRestaurantDetails.UserId = tblApproves.UserId;
                        tblRestaurantDetails.RestaurantId = Guid.NewGuid();
                        tblRestaurantDetails.RestaurantAvailabilityId = 1;
                        tblRestaurantDetails.ApproveId = approveId;
                        tblRestaurantDetails.Rating = 5;
                        tblRestaurantDetails.Discounts = 0;
                        await _DbContext.TblRestaurantDetails.AddAsync(tblRestaurantDetails);
                        if (await _DbContext.SaveChangesAsync() >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        throw new AlreadyRegisteredRestaurantException("Already Registered Restaurant");
                    }
                    

                }

            }
            catch (NoRestaurantRequestFound e)
            {
                throw new AllException(e.Message);
            }
            catch (AlreadyRegisteredRestaurantException e)
            {
                throw new AllException(e.Message);
            }
            catch (SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }

        }

        [ExcludeFromCodeCoverage]
        public async Task<bool> RejectRestaurent(int approveId)
        {
            try
            {
                TblApprove tblApproves = await _DbContext.TblApprove.FindAsync(approveId);
                if (tblApproves == null)
                {
                    throw new NoRestaurantRequestFound("Sorry,No Restaurant Request Found ");
                }
                else
                {
                    if (tblApproves.ApprovalStatusId == 1)
                    {
                        throw new AlreadyRegisteredRestaurantException("Already Registered ");
                    }
                    else
                    {
                          _DbContext.TblApprove.Remove(tblApproves);
                        if (await _DbContext.SaveChangesAsync() == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            catch (NoRestaurantRequestFound e )
            {
                throw new AllException(e.Message);
            }
            catch (SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }

        }
        [ExcludeFromCodeCoverage]
        public async  Task<List<tblRestaurantRequiredDetails>> GetAllRestaurants()
        {
            try
            {
                List<tblRestaurantRequiredDetails> tblRestaurantRequiredDetails = new List<tblRestaurantRequiredDetails>();
                var Value =await( from x in _DbContext.TblRestaurantDetails
                            join y in _DbContext.TblApprove on x.ApproveId equals y.ApproveId
                            join z in _DbContext.TblUserDetails on y.UserId equals z.UserId
                            //join p in _DbContext.TblAddressDetails on z.UserId equals p.UserId
                            select new
                            {
                                x.Rating,
                                x.Discounts,
                                y.RestaurantName,
                                z.UserMobile,
                                z.UserId,
                                z.ActiveUserId
                            }).ToListAsync();

                foreach (var item in Value)
                {
                    tblRestaurantRequiredDetails requiredDetails = new tblRestaurantRequiredDetails();
                    requiredDetails.Rating = item.Rating;
                    requiredDetails.UserMobile = item.UserMobile;
                    requiredDetails.RestaurantName = item.RestaurantName;
                    requiredDetails.Discounts = item.Discounts;
                    requiredDetails.UserId = item.UserId;
                    requiredDetails.ActiveUserID = item.ActiveUserId;
                    tblRestaurantRequiredDetails.Add(requiredDetails);
                }
                if (tblRestaurantRequiredDetails.Count == 0)
                {
                    throw new RestaurantNotFoundException("Sorry , No restaurant Found");
                }
                else
                {
                    return   tblRestaurantRequiredDetails;
                }


            }
            catch (RestaurantNotFoundException e)
            {

                throw new AllException(e.Message);
            }
            catch (SqlException e)
            {

                throw new AllException(e.Message);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }
        [ExcludeFromCodeCoverage]
        public async  Task<List<TblApprove>> GetAllRestaurantRequests()
        {
            try
            {

                List<TblApprove> tblApprovelist = await _DbContext.TblApprove.Where(i => i.ApprovalStatusId == 2).ToListAsync<TblApprove>();
                if (tblApprovelist.Count == 0)
                {
                    throw new NoRestaurantRequestFound("Sorry,No Restaurant Request Found ");
                }
                return tblApprovelist;
            }
            catch (NoRestaurantRequestFound e )
            {
                throw new AllException(e.Message);
            }
            catch (SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
        }

        public async Task<List<TblItemDetails>> GetAllRestaurantItems(Guid restaurentID)
        {
            try
            {
                List<TblItemDetails> tblItemDetailslist = new List<TblItemDetails>();
                tblItemDetailslist = new List<TblItemDetails>();
                tblItemDetailslist = await _DbContext.TblItemDetails.ToListAsync<TblItemDetails>();
                var list =  _DbContext.TblItemDetails.Where(x => x.RestaurantId == restaurentID);

                foreach (var item in list)
                {
                    tblItemDetailslist.Add(item);
                }
                return tblItemDetailslist;

            }
            catch (SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
        }
        public async Task<List<TblUserDetails>> GetAllUsers()
        {
            try
            {
                List<TblUserDetails> tblUserDetailslist = new List<TblUserDetails>();
                tblUserDetailslist = await _DbContext.TblUserDetails.ToListAsync<TblUserDetails>();
                return tblUserDetailslist;
            }
            catch (SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch (Exception e )
            {
                throw new AllException(e.Message);
            }
        }
        public async Task<List<TblOrder>> GetOrdersList()
        {
            try
            {
                List<TblOrder> TblOrderlist = new List<TblOrder>();
                TblOrderlist = await _DbContext.TblOrder.ToListAsync<TblOrder>();
                return TblOrderlist;
            }
            catch (SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
        }

        public async Task<bool> DeleteRestaurant(Guid id)
        {
            try
            {
                TblRestaurantDetails tblRestaurantDetails = new TblRestaurantDetails();
                tblRestaurantDetails = _DbContext.TblRestaurantDetails.Find(id);
                _DbContext.TblRestaurantDetails.Remove(tblRestaurantDetails);

                if(await  _DbContext.SaveChangesAsync()==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException e)
            {
                throw new  AllException(e.Message);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
        }

    }
}
