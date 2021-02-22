using BookYourMealAPI.Business.Services;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.DataAccess.Services;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static BookYourMeal.Tests.AddClass;

namespace BookYourMeal.Tests
{
    [TestClass]
    public class PaymentBLLTest
    {
        [TestMethod]
        public void GetWalletMoney_ShouldGetWalletMoney_Happy()
        {
            Guid userid = Guid.NewGuid();
            //Arrange
            Decimal? value = (decimal)1.000;
            Mock<IPaymentDA> mock = new Mock<IPaymentDA>();
            mock.Setup(x => x.GetWalletMoney(userid)).Returns(value);
            PaymentBll orderBll = new PaymentBll(mock.Object);

            //Act
            Decimal? valuef = orderBll.GetWalletMoney(userid);
            //Assert

            Assert.AreEqual(value, valuef);



        }
    }
}
