using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BookYourMealAPI.Business.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookYourMealAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class PaymentController : Controller
    {

        private readonly IPaymentBll _paymentBLL;
        public PaymentController(IPaymentBll paymentBLL)
        {
            _paymentBLL = paymentBLL;
        }
        [HttpGet]
        [Route("GetWalletMoney")]
        public ActionResult GetWalletMoney([FromQuery]Guid userId)
        {
            try
            {
                decimal?money=_paymentBLL.GetWalletMoney(userId);
                return Ok(new { message = money });
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpPut]
        [Route("UpdateWalletMoney")]
        public ActionResult UpdateWalletMoney([FromQuery]Guid UserID,[FromQuery]decimal WalletMoney)
        {
            try
            {
                _paymentBLL.UpdateWalletMoney(UserID, WalletMoney);

                return Ok(new { message = "Wallet Money Updated" });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }
    }
}