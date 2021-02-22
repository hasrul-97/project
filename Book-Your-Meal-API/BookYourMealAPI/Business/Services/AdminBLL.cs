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
    public class AdminBll : IAdminBll

    {
        private readonly IAdminDA _dataaccess;
        public AdminBll(IAdminDA dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public async Task<bool> DisableRestaurent(Guid userId)
        {
            try
            {
                 await _dataaccess.DisableRestaurent(userId);
                 return true;
                 
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
           

        }
        public async Task<bool> EnableRestaurent(Guid userId)
        {
            try
            {
                await _dataaccess.EnableRestaurent(userId);
                return true;
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
                 await _dataaccess.DisableCustomer(userId);
                 return true; 
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);

            }

        }
        public async Task<bool> ApproveRestaurent(int approveId)
        {
            
            try
            {
              await  _dataaccess.ApproveRestaurent(approveId);
                return true;

            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
            

        }
        public async Task<bool> RejectRestaurent(int approveId)
        {
            try
            {
              await _dataaccess.RejectRestaurent(approveId);
                return true;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }

        }
        public async Task<List<TblOrder>> GetOrdersList()
        {
            try
            {
                return  await  _dataaccess.GetOrdersList();
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }


        public async Task<List<tblRestaurantRequiredDetails>> GetAllRestaurants()
        {
            try
            {
                return await _dataaccess.GetAllRestaurants();
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }

        public async Task<List<TblApprove>> GetAllRestaurantRequests()
        {
            try
            {
                return await _dataaccess.GetAllRestaurantRequests();
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }

        public async Task<List<TblItemDetails>> GetAllItems(Guid id)
        {
            try
            {
                return  await _dataaccess.GetAllRestaurantItems(id);
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

                return  await _dataaccess.GetAllUsers();
            }

            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }

       

        public  async Task<bool>  DeleteRestaurant(Guid id)
        {
            try
            {
                  await _dataaccess.DeleteRestaurant(id);
                  return true;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }


    }
}
