using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.ENTITY
{
    class Item
    {
        char _bomb = 'B';
        char _key = 'K';
        char _chest = 'C';
        char _coin = '$';
        char _special = 'S';
        char _buyable = 'V';
        char _itemType;

        public char AddItemBomb()
        {
            _itemType = _bomb;
            return _itemType;
        }

        public char AddItemKey()
        {
            _itemType = _key;
            return _itemType;
        }

        public char AddItemChest()
        {
            _itemType = _chest;
            return _itemType;
        }

        public char AddItemCoin()
        {
            _itemType = _coin;
            return _itemType;
        }

        public char AddItemSpecial()
        {
            _itemType = _special;
            return _itemType;
        }

        public char AddItemBuyable()
        {
            _itemType = _buyable;
            return _itemType;
        }
    }
}
