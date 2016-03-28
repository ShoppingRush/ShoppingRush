using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Inventory))]
    public class ShopItemList : MonoBehaviour
    {
        private Dictionary<ShopItemData, int> _shopItemToCollect;

        public Dictionary<ShopItemData, int> ShopItemToCollect {
            get
            {
                return _shopItemToCollect;
            }
            set
            {
                _shopItemToCollect = value;
                RedrawUI();
            }
        }

        public Text ShopItemListText;

        private Inventory _inventory;

        // Use this for initialization
        void Start()
        {
            _shopItemToCollect = new Dictionary<ShopItemData, int>()
            {
                {new ShopItemData { ItemId = 0, ItemName = "Mleko" }, 10 },
                {new ShopItemData { ItemId = 1, ItemName = "Woda" }, 10 },
                {new ShopItemData { ItemId = 2, ItemName = "Sok" }, 10 },
                {new ShopItemData { ItemId = 3, ItemName = "Chleb" }, 10 },
                {new ShopItemData { ItemId = 4, ItemName = "Mleko" }, 10 }
            };


            _inventory = GetComponent<Inventory>();
            ShopItemListText.supportRichText = true;
            RedrawUI();
        }

        public void RedrawUI()
        {
            if (ShopItemListText != null)
            {
                ShopItemListText.text = String.Join("\n\r", ShopItemToCollect.Keys.
                    Select(item => getStringForItem(item, _inventory.GetAmountOfShopItemData(item))).ToArray<string>());
            }
            else
            {
                ShopItemListText.text = "";
            }
        }

        private string getStringForItem(ShopItemData item, int currentAmount)
        {
            return String.Format(getFormat(ShopItemToCollect[item], currentAmount), String.Format("{0}x {1}", ShopItemToCollect[item], item.ItemName));
        }

        private string getFormat(int number, int currentAmount)
        {
            return currentAmount >= number ? "<strike>{0}</strike>" : "{0}";
        }
    }
}
