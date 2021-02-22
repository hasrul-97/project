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
    public class RestaurantBll: IRestaurantBll
    {
        private readonly IRestaurantDA _restaurantDA;

        public RestaurantBll(IRestaurantDA restaurantDA)
        {
            _restaurantDA = restaurantDA;
        }
        public async Task<bool> AddItem(TblItemDetails tblItemDetails)
        {
            try
            {
                await _restaurantDA.AddItem(tblItemDetails);
                return true;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
            
        }

        public async Task<bool> DeleteItem(int itemId, Guid restaurantId)
        {
            try
            {
                await _restaurantDA.DeleteItem(itemId, restaurantId);
                return true;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
            
        }



        public List<TblItemDetails> GetRestaurantItems(Guid restaurantId)
        {
            try
            {
                return _restaurantDA.GetRestaurantItems(restaurantId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
           
        }

        public async Task<bool> EditItem(TblItemDetails tblItemDetails)
        {
            try
            {
                await _restaurantDA.EditItem(tblItemDetails);
                return true;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
            

        }

        public async Task<bool> UpdateRestaurantDiscount(Guid restaurantId, decimal discounts)
        {
            try
            {
                await _restaurantDA.UpdateRestaurantDiscount(restaurantId, discounts);
                return true;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
          
        }

        public RestaurantDetails GetRestaurantDetails(Guid userId)
        {
            try
            {
                return _restaurantDA.GetRestaurantDetails(userId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
            
        }
        public List<TblItemCategoryDetails> GetItemCategory()
        {
            try
            {
                return _restaurantDA.GetItemCategory();
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }
        public List<TblItemTypeDetails> GetItemType()
        {
            try
            {
                return _restaurantDA.GetItemType();
               
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }

        public async Task<bool> EditRestaurantDetails(RestaurantDetails restaurantDetails)
        {
            try
            {
                await _restaurantDA.EditRestaurantDetails(restaurantDetails);
                return true;

            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }
    }
}
