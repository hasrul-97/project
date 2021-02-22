
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Business.Repositories
{
    public interface IAdminBll
    {
        Task<bool> ApproveRestaurent(int approveId);
        Task<bool> RejectRestaurent(int approveId);
        Task<List<tblRestaurantRequiredDetails>> GetAllRestaurants();
        Task<List<TblApprove>> GetAllRestaurantRequests();
        Task<List<TblItemDetails>> GetAllItems(Guid id);
        Task<List<TblOrder>> GetOrdersList();
        Task<List<TblUserDetails>> GetAllUsers();
        Task<bool> DeleteRestaurant(Guid id);
        Task<bool> DisableCustomer(Guid userId);
        Task<bool> DisableRestaurent(Guid userId);
        Task<bool> EnableRestaurent(Guid userID);

    }
}
