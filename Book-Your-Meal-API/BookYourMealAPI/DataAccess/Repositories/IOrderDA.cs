using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.DataAccess.Repositories
{
    public interface IOrderDA
    {
        Guid AddAddress(string address, Guid userId);
        Task RemoveFavouriteRestaurant(Guid UserID, Guid RestaurantId);
        List<TblAddressDetails> GetAllUserAddress(Guid UserId);
        void AddFavouriteRestaurant(Guid UserID, Guid RestaurantId);
        void AddReview(TblReview tblReview);
        List<TblFavourite> GetFavouriteRestaurant(Guid UserId);
        Task<bool> PlaceOrder(PlaceOrder order);
   
    }
}
