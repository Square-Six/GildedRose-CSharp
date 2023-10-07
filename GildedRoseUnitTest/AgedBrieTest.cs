using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace GildedRoseUnitTest
{
    [TestClass]
    public class AgedBrieTest
    {
        public List<Item> Items { get; set; }

        Mock<GildedRose.GildedRose> GildedRoseMock;

        [TestMethod]
        public void AgedBrieQualityIncreasesByOneWhenSellInIsGreaterThanZero()
        {
            // Arrange
            Items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 0},
            };
            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 5; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(5, Items[0].Quality);
        }

        [TestMethod]
        public void AgedBrieQualityIncreasesByTwoWhenSellInIsNegative()
        {
            // Arrange
            Items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            };
            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 10; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(18, Items[0].Quality);
        }

        [TestMethod]
        public void AgedBrieNeverGreaterThan50()
        {
            // Arrange
            Items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 40},
            };

            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 100; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(50, Items[0].Quality);
        }
    }
}
