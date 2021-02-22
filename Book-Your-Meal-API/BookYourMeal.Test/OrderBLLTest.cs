using BookYourMealAPI.Business.Services;
using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookYourMeal.Tests
{
    [TestClass]
    public class OrderBLLTest
    {

        [TestMethod]
        public void GetItemType_ShouldGetItemTypeList_Happy()
        {
            Guid userid = Guid.NewGuid();
            //Arrange
            List<TblFavourite> list = new List<TblFavourite>();
            Mock<IOrderDA> mock = new Mock<IOrderDA>();
            mock.Setup(x => x.GetFavouriteRestaurant(userid)).Returns(list);
            OrderBll orderBll = new OrderBll(mock.Object);

            //Act
            List<TblFavourite> list1 = new List<TblFavourite>();
            list1 = orderBll.GetFavouriteRestaurant(userid);
            //Assert
            Assert.AreEqual(list, list1);

        }
        [TestMethod]
        public void AddAddress_ShouldAddAddress_Happy()
        {
            Guid userid = Guid.NewGuid();
            //Arrange
            string address="";
            Guid guid = Guid.NewGuid();
            Mock<IOrderDA> mock = new Mock<IOrderDA>();
            mock.Setup(x => x.AddAddress(address,userid)).Returns(guid);
            OrderBll orderBll = new OrderBll(mock.Object);

            //Act
            Guid guid1 = orderBll.AddAddress(address,guid);
            //Assert
            Assert.AreEqual(guid, guid1);

        }

        [TestMethod]
        public void GetAllUserAddress_ShouldReturnAddress_Happy()
        {
            Guid userid = Guid.NewGuid();
            //Arrange
            List<TblAddressDetails> list = new List<TblAddressDetails>();
            Mock<IOrderDA> mock = new Mock<IOrderDA>();
            mock.Setup(x => x.GetAllUserAddress(userid)).Returns(list);
            OrderBll orderBll = new OrderBll(mock.Object);

            //Act
            List<TblAddressDetails> mylist = orderBll.GetAllUserAddress(userid);
            //Assert
            Assert.AreEqual(mylist, list);

        }
        [TestMethod]
        public async void PlaceOrder_ShouldPlaceOrder_Happy()
        {

            //Arrange
            PlaceOrder placeOrder = new PlaceOrder();
            Mock<IOrderDA> mock = new Mock<IOrderDA>();
            mock.Setup(x => x.PlaceOrder(placeOrder)).ReturnsAsync(true);
            OrderBll orderBll = new OrderBll(mock.Object);

            //Act
            PlaceOrder placeOrder1 = new PlaceOrder();
            bool check = await orderBll.PlaceOrder(placeOrder1);
            //Assert
            Assert.AreEqual(true,check);

        }
    }
}