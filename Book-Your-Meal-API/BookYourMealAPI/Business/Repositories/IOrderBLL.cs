using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Business.Repositories
{
    public interface IOrderBll
    {
        List<TblAddressDetails> GetAllUserAddress(Guid UserId);
        void AddFavouriteRestaurant(Guid UserID, Guid RestaurantId);
        Task RemoveFavouriteRestaurant(Guid UserID, Guid RestaurantId);
        void AddReview(TblReview tblReview);
        Guid AddAddress(string address,  Guid userId);
        List<TblFavourite> GetFavouriteRestaurant(Guid UserId);
        Task<bool> PlaceOrder(PlaceOrder order);
    }
}
