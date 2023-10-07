using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseUnitTest
{
    [TestClass]
    public class SulfurasTest
    {
        public List<Item> Items { get; set; }

        Mock<GildedRose.GildedRose> GildedRoseMock;

        [TestMethod]
        public void SellInDoesNotChange()
        {
            // Arrange
            Items = new List<Item>()
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            };
            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);


            // Act
            for (var i = 0; i < 500; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(0, Items[0].SellIn);
        }

        [TestMethod]
        public void QualitynDoesNotChange()
        {
            // Arrange
            Items = new List<Item>()
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            };
            GildedRoseMock = new Mock<GildedRose.GildedRose>(Items);


            // Act
            for (var i = 0; i < 1500; i++)
            {
                GildedRoseMock.Object.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(80, Items[0].Quality);
        }
    }
}
