using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace GildedRoseUnitTest
{
    [TestClass]
    public class ConjuredTest
    {
        public List<Item> Items { get; set; }

        Mock<GildedRose.GildedRose> GildedRoseMock;

        [TestMethod]
        public void ConjuredQualityDecreaseByTwoWhenSellInIsGreaterThanZero()
        {
            // Arrange
            Items = new List<Item>{
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
            };
            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 1; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(4, Items[0].Quality);
        }

        [TestMethod]
        public void ConjuredQualityDecreaseByFourWhenSellInIsNegative()
        {
            // Arrange
            Items = new List<Item>{
                new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 6},
            };
            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 2; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(0, Items[0].Quality);
        }

        [TestMethod]
        public void ConjuredQualityIsNeverNegative()
        {
            // Arrange
            Items = new List<Item>{
                new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 6},
            };
            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 500; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}
