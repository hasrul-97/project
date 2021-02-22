
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.DataAccess.Repositories
{
    public interface IAdminDA
    {
        Task<bool> ApproveRestaurent(int approveId);
        Task<bool> RejectRestaurent(int approveId);
        Task<List<tblRestaurantRequiredDetails>> GetAllRestaurants();
        Task<List<TblApprove>> GetAllRestaurantRequests();
        Task<List<TblItemDetails>> GetAllRestaurantItems(Guid restaurentID);
        Task<List<TblUserDetails>> GetAllUsers();
        Task<List<TblOrder>> GetOrdersList();
        Task<bool> DeleteRestaurant(Guid id);
        Task<bool> DisableCustomer(Guid userId);
        Task<bool> DisableRestaurent(Guid userId);
        Task<bool> EnableRestaurent(Guid userId);

    }
}
