using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.DataAccess.Repositories
{
    public interface IRestaurantDA
    {
        RestaurantDetails GetRestaurantDetails(Guid userId);
        Task<bool> AddItem(TblItemDetails tblItemDetails);
        Task<bool> DeleteItem(int itemId, Guid restaurantId);
        List<TblItemDetails> GetRestaurantItems(Guid restaurantId);
        Task<bool> EditItem(TblItemDetails tblItemDetails);
        Task<bool> UpdateRestaurantDiscount(Guid restaurantId, decimal discounts);
        List<TblItemTypeDetails> GetItemType();
        List<TblItemCategoryDetails> GetItemCategory();
        Task<bool> EditRestaurantDetails(RestaurantDetails RestaurantDetails);
    }
}
