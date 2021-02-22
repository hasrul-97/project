using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BookYourMealAPI.Business.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookYourMealAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private readonly IAdminBll _adminBLL;
        public AdminController(IAdminBll adminBLL)
        {
            _adminBLL = adminBLL;
        }
        [HttpPut]
        [Route("ApproveRestaurant")]
        public async Task<ActionResult> ApproveRestaurent(int approveId)
        {
            try
            {
                await _adminBLL.ApproveRestaurent(approveId);
                return Ok(new { message="Approved" });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }
        [HttpPut]
        [Route("RejectRestaurant")]
        public async Task<ActionResult> RejectRestaurent(int approveId)
        {
            try
            {
                await _adminBLL.RejectRestaurent(approveId);
                return Ok(new { message = "Restaurant Rejected" });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }
        [HttpGet]
        [Route("GetRestaurantDetails")]
        public async Task<ActionResult<List<tblRestaurantRequiredDetails>>> GetRestaurantDetails()
        {
            try
            {
                return   Ok(await _adminBLL.GetAllRestaurants());
            }
            catch (Exception e)
            {
                return  BadRequest(new { message = e.Message });
            }
        }
        [HttpGet]
        [Route("GetRequestList")]
        public async Task<ActionResult<List<TblApprove>>> GetRequestList()
        {
            try
            {
                return Ok(await _adminBLL.GetAllRestaurantRequests());
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        
        [HttpGet]
        [Route("GetItemsList")]
        public async Task<ActionResult<List<TblItemDetails>>> GetItemsList(Guid id)
        {
            try
            {
                return Ok(await _adminBLL.GetAllItems(id));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpGet]
        [Route("GetUsersList")]
        public  async Task<ActionResult<List<TblUserDetails>>> GetUsersList()
        {
            try
            {
                return Ok( await _adminBLL.GetAllUsers());
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpGet]
        [Route("GetOrdersList")]
        public async Task<ActionResult<List<TblOrder>>> GetOrdersList()
        {
            try
            {
                return Ok(await _adminBLL.GetOrdersList());
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpGet]
        [Route("DeleteRestaurant")]
        public async Task<ActionResult> DeleteRestaurant(Guid id)
        {
            try
            {
                 await _adminBLL.DeleteRestaurant(id);
                 return Ok(new { message = "Deleted" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpPut]
        [Route("DisableRestaurent")]
        public async Task<ActionResult> DisableRestaurent(Guid userId)
        {
            try
            {
                await _adminBLL.DisableRestaurent(userId);
                return Ok(new { message = "Disable" });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }
        [HttpPut]
        [Route("EnableRestaurent")]
        public async Task<ActionResult> EnableRestaurent(Guid userId)
        {
            try
            {
                await _adminBLL.EnableRestaurent(userId);
                return Ok(new { message = "Enable" });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }
        [HttpPut]
        [Route("DisableCustomer")]
        public async Task<ActionResult> DisableCustomer(Guid userId)
        {
            try
            {
                await _adminBLL.DisableCustomer(userId);
                return Ok(new { message = "Disable" });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }



    }
}