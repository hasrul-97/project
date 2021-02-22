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
    public class RestaurantBLLTest
    {

        [TestMethod]
        public void  GetItemType_ShouldGetItemTypeList_Happy()
        {
            //Arrange
            List<TblItemTypeDetails> list = new List<TblItemTypeDetails>();
            Mock<IRestaurantDA> mock = new Mock<IRestaurantDA>();
            mock.Setup(x => x.GetItemType()).Returns(list);
            RestaurantBll restaurantBLL = new RestaurantBll(mock.Object);

            //Act
            List<TblItemTypeDetails> list1 = new List<TblItemTypeDetails>();
            list1 = restaurantBLL.GetItemType();
            //Assert
            Assert.AreEqual(list, list1);

        }
        //[TestMethod]
        //public void GetItemType_ShouldGetItemTypeList_Sad()
        //{
        //    //Arrange
           
        //    Mock<IRestaurantDA> mock = new Mock<IRestaurantDA>();
        //    mock.Setup(x => x.GetItemType()).Throws(new AllException(""));
        //    RestaurantBll restaurantBll = new RestaurantBll(mock.Object);

        //    //Act

        //    //Assert
        //    Assert.ThrowsExceptionAsync<AllException>(() => restaurantBll.GetItemType());
        //}
        [TestMethod]
        public void GetItemCategory_ShouldGetItemCategoryList_Happy()
        {
            //Arrange
            List<TblItemCategoryDetails> list = new List<TblItemCategoryDetails>();
            Mock<IRestaurantDA> mock = new Mock<IRestaurantDA>();
            mock.Setup(x => x.GetItemCategory()).Returns(list);
            RestaurantBll restaurantBLL = new RestaurantBll(mock.Object);

            //Act
            List<TblItemCategoryDetails> list1 = new List<TblItemCategoryDetails>();
            list1 = restaurantBLL.GetItemCategory();
            //Assert
            Assert.AreEqual(list, list1);

        }
        [TestMethod]
        public async Task AddItem_ShouldAddItem_Happy()
        {
            //Arrange
            TblItemDetails tblItemDetails = new TblItemDetails();
            Mock<IRestaurantDA> mock = new Mock<IRestaurantDA>();
             mock.Setup(x => x.AddItem(tblItemDetails)).ReturnsAsync(true);
            RestaurantBll restaurantBLL = new RestaurantBll(mock.Object);

            //Act
            TblItemDetails list1 = new TblItemDetails();
            bool check = await restaurantBLL.AddItem(tblItemDetails);
            //Assert
            Assert.IsTrue(check);

        }
        [TestMethod]
        public async Task DeleteItem_ShouldEDeleteItem_Happy()
        {
            //Arrange
            
            int itemId = 5;
            Guid guid = Guid.NewGuid();
            Mock<IRestaurantDA> mock = new Mock<IRestaurantDA>();
            mock.Setup(x => x.DeleteItem(itemId,guid)).ReturnsAsync(true);
            RestaurantBll restaurantBLL = new RestaurantBll(mock.Object);

            //Act
            
            bool check = await restaurantBLL.DeleteItem(itemId, guid);
            //Assert
            Assert.IsTrue(check);

        }
        [TestMethod]
        public async Task EditItem_ShouldEditItem_Happy()
        {
            //Arrange
            TblItemDetails tblItemDetails = new TblItemDetails();
            Mock<IRestaurantDA> mock = new Mock<IRestaurantDA>();
            mock.Setup(x => x.EditItem(tblItemDetails)).ReturnsAsync(true);
            RestaurantBll restaurantBLL = new RestaurantBll(mock.Object);

            //Act
            TblItemDetails list1 = new TblItemDetails();
            bool check = await restaurantBLL.EditItem(tblItemDetails);
            //Assert
            Assert.IsTrue(check);

        }
        [TestMethod]
        public async Task UpdateRestaurantDiscount_ShouldUpdateRestaurantDiscount_Happy()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            decimal discount = 2;
            Mock<IRestaurantDA> mock = new Mock<IRestaurantDA>();
            mock.Setup(x => x.UpdateRestaurantDiscount(guid,discount)).ReturnsAsync(true);
            RestaurantBll restaurantBLL = new RestaurantBll(mock.Object);

            //Act
            TblItemDetails list1 = new TblItemDetails();
            bool check = await restaurantBLL.UpdateRestaurantDiscount(guid,discount);
            //Assert
            Assert.IsTrue(check);

        }
        [TestMethod]
        public void GetRestaurantItems_ShouldGetRestaurantItems_Happy()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            List<TblItemDetails> tblItemDetails = new List<TblItemDetails>();
            Mock<IRestaurantDA> mock = new Mock<IRestaurantDA>();
            mock.Setup(x => x.GetRestaurantItems(guid)).Returns(tblItemDetails);
            RestaurantBll restaurantBLL = new RestaurantBll(mock.Object);

            //Act
            List<TblItemDetails> tblItemDetails1 = new List<TblItemDetails>();
            tblItemDetails1 = restaurantBLL.GetRestaurantItems(guid);
            //Assert
            Assert.AreEqual(tblItemDetails, tblItemDetails1);

        }

        [TestMethod]
        public void GetRestaurantDetails_ShouldGetRestaurantDetails_Happy()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            RestaurantDetails restaurantDetails = new RestaurantDetails();
           
            Mock<IRestaurantDA> mock = new Mock<IRestaurantDA>();
            mock.Setup(x => x.GetRestaurantDetails(guid)).Returns(restaurantDetails);
            RestaurantBll restaurantBLL = new RestaurantBll(mock.Object);

            //Act
            RestaurantDetails restaurantDetails1 = new RestaurantDetails();
            restaurantDetails1 = restaurantBLL.GetRestaurantDetails(guid);
            //Assert
            Assert.AreEqual(restaurantDetails, restaurantDetails1);

        }
        [TestMethod]
        public async Task EditRestaurantDetails_ShouldEditRestaurantDetails_Happy()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            RestaurantDetails restaurantDetails = new RestaurantDetails();

            Mock<IRestaurantDA> mock = new Mock<IRestaurantDA>();
            mock.Setup(x => x.EditRestaurantDetails(restaurantDetails)).ReturnsAsync(true);
            RestaurantBll restaurantBLL = new RestaurantBll(mock.Object);

            //Act
            RestaurantDetails restaurantDetails1 = new RestaurantDetails();
            bool check = await restaurantBLL.EditRestaurantDetails(restaurantDetails1);
            //Assert
            Assert.IsTrue(check);

        }

    }
}