using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Business.Repositories
{
    public interface ICustomerBll
    {
        List<ItemRequiredDetails> FilteredItems(Guid restaurantId, Filter filter);
        void RegisterRestaurant(TblApprove tblApprove);

        List<PastOrderDetails> GetPastOrder(Guid userId);

        List<string> GetPastOrderItemDetails(Guid orderId);

        List<RestaurantDetails> GetAllRestaurent();
        List<RestaurantDetails> GetAllRestaurentLoc(double latitude, double longitude);

        List<BookmarkedRestaurant> GetAllBookMarkedRestaurent(Guid userId);

        TblUserDetails GetProfileDetails(Guid userId);

        void EditProfile(Guid userId, TblUserDetails tblUserDetails);

        List<string> Search(string str);

        List<TblItemDetails> GetResaturentItemDetails(Guid restaurentId);
        List<TblItemDetails> GetAllItemDetails();
        
    }
}
