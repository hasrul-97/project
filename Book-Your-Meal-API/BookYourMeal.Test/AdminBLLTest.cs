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
    public class AdminBllTest
    {
        [TestMethod]
        public async Task DisableRestaurant_ShouldDisableReastaurant_Happy()
        {
            //Arrange
            Guid UserId = Guid.NewGuid();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.DisableRestaurent(UserId)).ReturnsAsync(true);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            bool actual = await adminBLL.DisableRestaurent(UserId);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public async Task DisableRestaurant_ShouldDisableReastaurant_Sad()
        {
            //Arrange
            Guid UserId = Guid.NewGuid();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.DisableRestaurent(UserId)).Throws(new AllException(""));
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            
            //Assert
            await Assert.ThrowsExceptionAsync<AllException> (async()=> await adminBLL.DisableRestaurent(UserId));
        }
        
        [TestMethod]
        public async Task DeleteRestaurant_ShouldDeleteReastaurant_Happy()
        {
            //Arrange
            Guid UserId = Guid.NewGuid();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.DeleteRestaurant(UserId)).ReturnsAsync(true);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            bool actual = await adminBLL.DeleteRestaurant(UserId);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public async Task DeleteRestaurant_ShouldDeleteReastaurant_Sad()
        {
            //Arrange
            Guid UserId = Guid.NewGuid();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.DeleteRestaurant(UserId)).Throws(new AllException(""));
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            //bool actual = await adminBLL.DeleteRestaurant(UserId);
            //Assert
            await Assert.ThrowsExceptionAsync<AllException> (async()=> await adminBLL.DeleteRestaurant(UserId));
        }

        [TestMethod]
        public async Task EnableRestaurant_ShouldEnableReastaurant_Happy()
        {
            //Arrange
            Guid UserId = Guid.NewGuid();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.EnableRestaurent(UserId)).ReturnsAsync(true);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            bool actual = await adminBLL.EnableRestaurent(UserId);
            //Assert
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public async Task EnableRestaurant_ShouldEnableReastaurant_Sad()
        {
            //Arrange
            Guid UserId = Guid.NewGuid();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.EnableRestaurent(UserId)).Throws(new AllException(""));
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
           // bool actual = await adminBLL.EnableRestaurent(UserId);
            //Assert
            await Assert.ThrowsExceptionAsync<AllException>(async()=> await adminBLL.EnableRestaurent(UserId));

        }
        [TestMethod]
        public async Task DisableCustomer_ShouldDisableCustomer_Happy()
        {
            //Arrange
            Guid UserId = Guid.NewGuid();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.EnableRestaurent(UserId)).ReturnsAsync(true);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            bool actual = await adminBLL.EnableRestaurent(UserId);
            //Assert
            Assert.IsTrue(actual);

        }

        [TestMethod]
        public async Task DisableCustomer_ShouldDisableCustomer_Sad()
        {
            //Arrange
            Guid UserId = Guid.NewGuid();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.DisableCustomer(UserId)).ThrowsAsync(new AllException(""));
            AdminBll adminBLL = new AdminBll(mock.Object);

           //Act
           // bool actual = await adminBLL.EnableRestaurent(UserId);
           //Assert

            await Assert.ThrowsExceptionAsync<AllException>(async () => await adminBLL.DisableCustomer(UserId));
        }

        [TestMethod]
        public async Task ApproveRestaurant_ShouldApproveRestaurant_Happy()
        {
            //Arrange
            int approveId = 1;
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.ApproveRestaurent(approveId)).ReturnsAsync(true);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            bool actual = await adminBLL.ApproveRestaurent(approveId);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public async Task ApproveRestaurant_ShouldApproveRestaurant_Sad()
        {
            //Arrange
            int approveId = 1;
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.ApproveRestaurent(approveId)).Throws(new AllException(""));
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            //bool actual = await adminBLL.ApproveRestaurent(approveId);
            //Assert
            await Assert.ThrowsExceptionAsync<AllException>(async()=> await adminBLL.ApproveRestaurent(approveId));
        }
        [TestMethod]
        public async Task RejectRestaurant_ShouldRejectRestaurant_Happy()
        {
            //Arrange
            int approveId = 1;
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.RejectRestaurent(approveId)).ReturnsAsync(true);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            bool actual = await adminBLL.RejectRestaurent(approveId);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public async Task RejectRestaurant_ShouldRejectRestaurant_Sad()
        {
            //Arrange
            int approveId = 1;
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.RejectRestaurent(approveId)).Throws(new AllException(""));
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            //Assert
            await Assert.ThrowsExceptionAsync<AllException>(async () => await adminBLL.RejectRestaurent(approveId));
        }
        [TestMethod]
        public async Task GetOrderList_ShouldGetOrderList_Happy()
        {
            //Arrange
            List<TblOrder> list = new List<TblOrder>();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.GetOrdersList()).ReturnsAsync(list);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            List<TblOrder> list1 = new List<TblOrder>();
            list1 = await adminBLL.GetOrdersList();
            //Assert
            Assert.AreEqual(list, list1);

        }

        [TestMethod]
        public async Task GetOrderList_ShouldGetOrderList_Sad()
        {
            //Arrange
            List<TblOrder> list = new List<TblOrder>();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.GetOrdersList()).Throws(new AllException(""));
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            //Assert
            await Assert.ThrowsExceptionAsync<AllException>(async () => await adminBLL.GetOrdersList());

        }

        [TestMethod]
        public async Task GetAllRestaurants_ShouldGetAllRestaurants_Happy()
        {
            //Arrange
            List<tblRestaurantRequiredDetails> list = new List<tblRestaurantRequiredDetails>();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.GetAllRestaurants()).ReturnsAsync(list);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            List<tblRestaurantRequiredDetails> list1 = new List<tblRestaurantRequiredDetails>();
            list1 = await adminBLL.GetAllRestaurants();
            //Assert
            Assert.AreEqual(list, list1);

        }

        [TestMethod]
        public async Task GetAllRestaurants_ShouldGetAllRestaurants_Sad()
        {
            //Arrange
            List<tblRestaurantRequiredDetails> list = new List<tblRestaurantRequiredDetails>();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.GetAllRestaurants()).Throws(new AllException(""));
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            //Assert
            await Assert.ThrowsExceptionAsync<AllException>(async () => await adminBLL.GetAllRestaurants());

        }

        [TestMethod]
        public async Task GetAllRestaurantRequests_ShouldGetAllRestaurantRequests_Happy()
        {
            //Arrange
            List<TblApprove> list = new List<TblApprove>();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.GetAllRestaurantRequests()).ReturnsAsync(list);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            List<TblApprove> list1 = new List<TblApprove>();
            list1 = await adminBLL.GetAllRestaurantRequests();
            //Assert
            Assert.AreEqual(list, list1);

        }

        [TestMethod]
        public async Task GetAllRestaurantRequests_ShouldGetAllRestaurantRequests_Sad()
        {
            //Arrange
            List<TblApprove> list = new List<TblApprove>();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.GetAllRestaurantRequests()).Throws(new AllException(""));
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            //Assert
            await Assert.ThrowsExceptionAsync<AllException>(async () => await adminBLL.GetAllRestaurantRequests());
        }



        [TestMethod]
        public async Task GetAllItems_ShouldGetAllItems_Happy()
        {
            //Arrange
            List<TblItemDetails> list = new List<TblItemDetails>();
            Guid guid = Guid.NewGuid();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.GetAllRestaurantItems(guid)).ReturnsAsync(list);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            List<TblItemDetails> list1 = new List<TblItemDetails>();
            list1 = await adminBLL.GetAllItems(guid);
            //Assert
            Assert.AreEqual(list, list1);

        }

        [TestMethod]
        public async Task GetAllUsers_ShouldGetAllUsers_Happy()
        {
            //Arrange
            List<TblUserDetails> list = new List<TblUserDetails>();
            Guid guid = Guid.NewGuid();
            Mock<IAdminDA> mock = new Mock<IAdminDA>();
            mock.Setup(x => x.GetAllUsers()).ReturnsAsync(list);
            AdminBll adminBLL = new AdminBll(mock.Object);

            //Act
            List<TblUserDetails> list1 = new List<TblUserDetails>();
            list1 = await adminBLL.GetAllUsers();
            //Assert
            Assert.AreEqual(list, list1);

        }

    }
}