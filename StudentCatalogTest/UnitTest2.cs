using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentCatalog.UnitTestExample;

namespace StudentCatalogTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestDiscountRules_NoDiscountValidInput_NoDiscount()
        {
            //Arrange
            DiscountRules discountRules = 
                new DiscountRules();

            //Act
            int discount = discountRules.ApplyDiscount(84);

            //Assert
            Assert.AreEqual(0, discount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDiscountRules_NoDiscountInvalidInput_NoDiscount()
        {
            //Arrange
            DiscountRules discountRules =
                new DiscountRules();

            //Act
            int discount = discountRules.ApplyDiscount(-100);

        }
        [TestMethod]
        public void TestDiscountRules_NoDiscountValidInput2_NoDiscount()
        {
            //Arrange
            DiscountRules discountRules =
                new DiscountRules();

            //Act
            int discount = discountRules.ApplyDiscount(99);

            //Assert
            Assert.AreEqual(0, discount);
        }


        [TestMethod]
        public void TestDiscountRules_NoDiscountValidInput3_NoDiscount()
        {
            //Arrange
            DiscountRules discountRules =
                new DiscountRules();

            //Act
            int discount = discountRules.ApplyDiscount(100);

            //Assert
            Assert.AreEqual(10, discount);
        }

        [TestMethod]
        public void TestDiscountRules_Discount10ValidInput4_NoDiscount()
        {
            //Arrange
            DiscountRules discountRules =
                new DiscountRules();

            //Act
            int discount = discountRules.ApplyDiscount(500);

            //Assert
            Assert.AreEqual(10, discount);
        }

        [TestMethod]
        public void TestDiscountRules_Discount15ValidInput5_NoDiscount()
        {
            //Arrange
            DiscountRules discountRules =
                new DiscountRules();

            //Act
            int discount = discountRules.ApplyDiscount(501);

            //Assert
            Assert.AreEqual(15, discount);
        }

        [TestMethod]
        public void TestDiscountRules_Discount15ValidInput6_NoDiscount()
        {
            //Arrange
            DiscountRules discountRules =
                new DiscountRules();

            //Act
            int discount = discountRules.ApplyDiscount(10069);

            //Assert
            Assert.AreEqual(15, discount);
        }
    }
}
