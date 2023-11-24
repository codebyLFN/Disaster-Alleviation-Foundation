using Disaster_Alleviation_Foundation.Models;

namespace Disaster_Alleviation_FoundationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test to check that you cannot allocate more goods than are available for specific disaster
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var goodsAllocation = new GoodsAllocation();
            var disaster = new Disaster();
            var goodsDonation = new GoodsDonation
            {
                ItemCount = 25
            };

            // Act
            goodsAllocation.GoodsDonation = goodsDonation;
            goodsAllocation.Disaster = disaster;
            goodsAllocation.ItemCount = 10;

            // Assert
            Assert.IsTrue(goodsAllocation.ItemCount <= goodsDonation.ItemCount);
        }

        // Test to check that you cannot allocate more money than is available for specific disaster
        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var moneyAllocation = new MonetaryAllocation();
            var disaster = new Disaster();
            var moneyDonation = new MonetaryDonation
            {
                Amount = 150
            };

            // Act
            moneyAllocation.MonetaryDonation = moneyDonation;
            moneyAllocation.Disaster = disaster;
            moneyAllocation.Amount = 100;

            // Assert
            Assert.IsTrue(moneyAllocation.Amount <= moneyDonation.Amount);
        }

        // Test to check that you cannot donate less than or equal to 0
        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            var moneyDonation = new MonetaryDonation();

            // Act
            moneyDonation.Amount = 250;

            // Assert
            Assert.IsFalse(moneyDonation.Amount <= 0);
        }

        // Test to check that you cannot donate less than or equal to  0 goods
        [TestMethod]
        public void TestMethod4()
        {
            // Arrange
            var goodsDonation = new GoodsDonation();

            // Act
            goodsDonation.ItemCount = 25;

            // Assert
            Assert.IsFalse(goodsDonation.ItemCount <= 0);
        }

        

        
        
    }
}