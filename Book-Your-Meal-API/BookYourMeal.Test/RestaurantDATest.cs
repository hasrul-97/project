using BookYourMealAPI.DataAccess.Services;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static BookYourMeal.Tests.AddClass;

namespace BookYourMeal.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class RestaurantDATest
    {
        [TestMethod]
        public void GetItemType_ShouldReturnListItemType_Happy()
        {

            var data = new List<TblItemTypeDetails>()
            {



                new TblItemTypeDetails
                {

                },
                new TblItemTypeDetails
                {

                }
               }.AsQueryable();
            var mockDbSet = new Mock<DbSet<TblItemTypeDetails>>();
            mockDbSet.As<IAsyncEnumerable<TblItemTypeDetails>>()
                .Setup(d => d.GetEnumerator())
                .Returns(new AsyncEnumerator<TblItemTypeDetails>(data.GetEnumerator()));



            mockDbSet.As<IQueryable<TblItemTypeDetails>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<TblItemTypeDetails>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<TblItemTypeDetails>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<TblItemTypeDetails>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockCtx = new Mock<Orchard8Context>();
            mockCtx.SetupGet(c => c.TblItemTypeDetails).Returns(mockDbSet.Object);
            var service = new RestaurantDA(mockCtx.Object);
            var expectedlist = service.GetItemType();
            Assert.AreEqual(2, expectedlist.Count);
        }
        [TestMethod]
        public void GetItemCategory_ShouldReturnListItemCategory_Happy()
        {

            var data = new List<TblItemCategoryDetails>()
            {



                new TblItemCategoryDetails
                {

                },
                new TblItemCategoryDetails
                {

                }
               }.AsQueryable();
            var mockDbSet = new Mock<DbSet<TblItemCategoryDetails>>();
            mockDbSet.As<IAsyncEnumerable<TblItemCategoryDetails>>()
                .Setup(d => d.GetEnumerator())
                .Returns(new AsyncEnumerator<TblItemCategoryDetails>(data.GetEnumerator()));



            mockDbSet.As<IQueryable<TblItemCategoryDetails>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<TblItemCategoryDetails>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<TblItemCategoryDetails>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<TblItemCategoryDetails>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockCtx = new Mock<Orchard8Context>();
            mockCtx.SetupGet(c => c.TblItemCategoryDetails).Returns(mockDbSet.Object);
            var service = new RestaurantDA(mockCtx.Object);
            var expectedlist = service.GetItemCategory();
            Assert.AreEqual(2, expectedlist.Count);
        }
    }
}
