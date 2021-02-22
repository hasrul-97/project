using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookYourMealAPI.Business.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantBll _restaurantBA;
        public RestaurantController(IRestaurantBll restaurantBA)
        {
            _restaurantBA = restaurantBA;
        }
        [HttpGet]
        [Route("GetRestaurantDetails")]
        public ActionResult GetRestaurantDetails(Guid userId)
        {
            try
            {
                _restaurantBA.GetRestaurantDetails(userId);
                return Ok(_restaurantBA.GetRestaurantDetails(userId));
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }
        [HttpPut]
        [Route("UpdateDiscount")]
        public async Task<ActionResult> UpdateDiscount(Guid restaurantId, decimal discounts)
        {
            try
            {
                 await _restaurantBA.UpdateRestaurantDiscount(restaurantId, discounts);
                return Ok(new
                {
                    message = "Discount is updated successfully"
                });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }




        }

        [HttpPost]
        [Route("AddItem")]
        public async Task<ActionResult> AddItem(ItemDetails itemdetails)
        {
            try
            {
                TblItemDetails tblItemDetails = new TblItemDetails();
                tblItemDetails.ItemName = itemdetails.ItemName;
                tblItemDetails.ItemTypeId = itemdetails.ItemTypeId;
                tblItemDetails.ItemPrice = itemdetails.ItemPrice;
                tblItemDetails.ItemImage = itemdetails.ItemImage;
                tblItemDetails.ItemCategoryId = itemdetails.ItemCategoryId;
                tblItemDetails.RestaurantId = itemdetails.RestaurantId;
                await _restaurantBA.AddItem(tblItemDetails);
                return Ok(new
                {
                    message = " Items added successfully"
                });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }


        }


        [HttpPost]
        [Route("EditItem")]
        public async Task<ActionResult> EditItem(ItemDetails itemdetails)
        {
            try
            {
                TblItemDetails tblItemDetails = new TblItemDetails();
                tblItemDetails.ItemId = itemdetails.ItemId;
                tblItemDetails.ItemName = itemdetails.ItemName;
                tblItemDetails.ItemTypeId = itemdetails.ItemTypeId;
                tblItemDetails.ItemPrice = itemdetails.ItemPrice;
                tblItemDetails.ItemImage = itemdetails.ItemImage;
                tblItemDetails.ItemCategoryId = itemdetails.ItemCategoryId;
                tblItemDetails.RestaurantId = itemdetails.RestaurantId;
                tblItemDetails.ItemId = itemdetails.ItemId;
                 await _restaurantBA.EditItem(tblItemDetails);
                return Ok(new
                {
                    message = "Food item is updated successfully"
                });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }



        }
        [HttpDelete]
        [Route("DeleteItem")]
        public async Task<ActionResult> DeleteItem(int itemid, Guid restaurantid)
        {
            try
            {
                await _restaurantBA.DeleteItem(itemid, restaurantid);
                return Ok(new
                {
                    message = "food item is deleted successfully"
                });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }


        }
        [HttpGet]
        [Route("GetRestaurantItems")]
        public  ActionResult GetRestaurantItems(Guid restaurantId)
        {
            try
            {
                _restaurantBA.GetRestaurantItems(restaurantId);
                return Ok(_restaurantBA.GetRestaurantItems(restaurantId));
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }


        }
        [HttpGet]
        [Route("GetItemType")]
        public ActionResult<List<TblItemTypeDetails>> GetItemType()
        {
            try
            {
                return Ok(_restaurantBA.GetItemType());
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpGet]
        [Route("GetItemCategory")]
        public ActionResult<List<TblItemCategoryDetails>> GetItemCategory()
        {
            try
            {
                return Ok(_restaurantBA.GetItemCategory());
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpPost]
        [Route("EditRestaurantDetails")]
        public async Task<IActionResult> EditRestaurantDetails(RestaurantDetails restaurantDetails)
        {
            try
            {
                 await _restaurantBA.EditRestaurantDetails(restaurantDetails);
                return Ok(new { message = "Restaurant Profile Updated Successfully" });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }   
        [HttpPost]
        [Route("Mail")]

        public void SendMail([FromBody] Mail mailData)

        {
            var emailObj = new MimeMessage();
            emailObj.From.Add(new MailboxAddress("BookYourMeal", "bookyourmeal.ofc@gmail.com"));
            emailObj.To.Add(new MailboxAddress("UserAddress", "hasrul997@gmail.com"));         //email content
            emailObj.Subject = "Help Request- "+mailData.Need;
            emailObj.Body = new TextPart("Plain")
            {
                Text = "FirstName: "+mailData.FirstName+"\nLastName: "+mailData.LastName+"\n\nHelp Message: "+mailData.MessageBody + "\n\nThis help is raised by: "+mailData.Email 
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("bookyourmeal.ofc@gmail.com", "mindtreeproject");   //smtp client setup and send
                client.Send(emailObj);
                client.Disconnect(true);
            }


        }

    }
}