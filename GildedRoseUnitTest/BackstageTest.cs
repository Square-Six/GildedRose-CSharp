using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace GildedRoseUnitTest
{
    [TestClass]
    public class BackstageTest
    {
        public List<Item> Items { get; set; }

        Mock<GildedRose.GildedRose> GildedRoseMock;

        [TestMethod]
        public void BackstageQualityIncreasesByOneWithSellInGreaterThan10()
        {
            // Arrange
            Items = new List<Item>{
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
            };

            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 5; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(25, Items[0].Quality);
        }

        [TestMethod]
        public void BackstageQualityIncreasesByTwoWithSellInLessThan10()
        {
            // Arrange
            Items = new List<Item>{
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 20
                },
            };

            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 5; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(30, Items[0].Quality);
        }

        [TestMethod]
        public void BackstageQualityIncreasesByThreeWithSellInLessThan5()
        {
            // Arrange
            Items = new List<Item>{
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 20
                },
            };

            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 5; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(35, Items[0].Quality);
        }

        [TestMethod]
        public void BackstageQualityDropsToZeroWhenSellInIsNegative()
        {
            // Arrange
            Items = new List<Item>{
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 20
                },
            };

            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 15; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(0, Items[0].Quality);
        }

        [TestMethod]
        public void BackstageQualityNeverGreaterThan50()
        {
            // Arrange
            Items = new List<Item>{
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 35
                },
            };

            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);

            // Act
            for (var i = 0; i < 15; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(50, Items[0].Quality);
        }
    }
}
