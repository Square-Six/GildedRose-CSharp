using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Update(Items[i]);
            }
        }

        /// <summary>
        /// Update Item. If SellIn is decreased it will run recursivelly
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isSellInDecreased"></param>
        private void Update(Item item, bool isSellInDecreased = false)
        {
            bool sellInDecrease = true;
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    sellInDecrease = false;
                    break;
                case "Aged Brie":
                    UpdateBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstage(item);
                    break;
                case "Conjured Mana Cake":
                    UpdateConjured(item);
                    break;
                default:
                    UpdateItem(item);
                    break;
            }
            if (sellInDecrease && !isSellInDecreased)
            {
                item.SellIn -= 1;
                if (item.SellIn < 0)
                {
                    Update(item, true);
                }
            }
        }
        /// <summary>
        /// Updates Brie Quality
        /// </summary>
        /// <param name="item"></param>
        private void UpdateBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        /// <summary>
        /// Updates Backstage Quality
        /// </summary>
        /// <param name="item"></param>
        private void UpdateBackstage(Item item)
        {
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality = 0;
                return;
            }

            if (item.Quality < 50)
            {
                item.Quality += 1;
            }

            if (item.SellIn <= 10 && item.Quality < 50)
            {
                item.Quality += 1;
            }

            if (item.SellIn <= 5 && item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        /// <summary>
        /// Updates Conjured Item
        /// </summary>
        /// <param name="item"></param>
        private void UpdateConjured(Item item)
        {
            if (item.Quality == 0)
            {
                return;
            }

            if (item.Quality == 1)
            {
                item.Quality -= 1;
            }
            else
            {
                item.Quality -= 2;
            }
        }

        /// <summary>
        /// Updates Quality of an item
        /// </summary>
        /// <param name="item"></param>
        private void UpdateItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }
}
