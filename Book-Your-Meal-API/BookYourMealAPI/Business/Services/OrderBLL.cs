using BookYourMealAPI.Business.Repositories;
using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Business.Services
{
    public class OrderBll:IOrderBll
    {
        private readonly IOrderDA _dataaccess;
        public OrderBll(IOrderDA dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public List<TblAddressDetails> GetAllUserAddress(Guid UserId)
        {
            try
            {
                return _dataaccess.GetAllUserAddress(UserId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }
        [ExcludeFromCodeCoverage]
        public void AddFavouriteRestaurant(Guid UserID, Guid RestaurantId)
        {
            try
            {
                _dataaccess.AddFavouriteRestaurant(UserID,RestaurantId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }

        }

        [ExcludeFromCodeCoverage]
        public  async Task RemoveFavouriteRestaurant(Guid UserID, Guid RestaurantId)
        {
            try
            {
                await _dataaccess.RemoveFavouriteRestaurant(UserID, RestaurantId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }

        }
        [ExcludeFromCodeCoverage]
        public void AddReview(TblReview tblReview)
        {
            try
            {
                _dataaccess.AddReview(tblReview);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }

        }
        public Guid AddAddress(string address, Guid userId)
        {
            try
            {
                return _dataaccess.AddAddress(address,userId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }

        }
        public List<TblFavourite> GetFavouriteRestaurant(Guid UserId)
        {
            try
            {
                return _dataaccess.GetFavouriteRestaurant(UserId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }

        [ExcludeFromCodeCoverage]
        public async Task<bool> PlaceOrder(PlaceOrder order)
        {
            try
            {
                return await _dataaccess.PlaceOrder(order);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }
    }
}
