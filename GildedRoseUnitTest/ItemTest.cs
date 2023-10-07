using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace GildedRoseUnitTest
{
    [TestClass]
    public class ItemTest
    {
        public List<Item> Items { get; set; }

        Mock<GildedRose.GildedRose> GildedRoseMock;

        [TestMethod]
        public void ConjuredQualityDecreaseByOneWhenSellInIsGreaterThanZero()
        {
            // Arrange
            Items = new List<Item>{
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            };
            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 1; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(6, Items[0].Quality);
        }

        [TestMethod]
        public void ConjuredQualityDecreaseByTwoWhenSellInIsNegative()
        {
            // Arrange
            Items = new List<Item>{
                new Item {Name = "Elixir of the Mongoose", SellIn = 2, Quality = 7},
            };
            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 3; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(3, Items[0].Quality);
        }

        [TestMethod]
        public void ConjuredQualityQualityNeverNegative()
        {
            // Arrange
            Items = new List<Item>{
                new Item {Name = "Elixir of the Mongoose", SellIn = 2, Quality = 7},
            };
            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 300; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}
