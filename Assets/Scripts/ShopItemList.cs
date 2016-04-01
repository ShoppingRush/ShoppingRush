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
        public float Margin = 8;

        public Image ShopItemListPanel;

        public GameObject TextPrefab;

        public Dictionary<ShopItemData, int> ShopItemToCollect {
            get
            {
                return _shopItemToCollect;
            }
            set
            {
                _shopItemToCollect = value;
                RedrawUi();
            }
        }

        private Dictionary<ShopItemData, int> _shopItemToCollect;

        private Inventory _inventory;

        // Use this for initialization
        void Start()
        {
            _shopItemToCollect = new Dictionary<ShopItemData, int>()
            {
                {new ShopItemData { ItemId = 0, ItemName = "Mleko" }, 10 },
                {new ShopItemData { ItemId = 1, ItemName = "Woda" }, 10 },
                {new ShopItemData { ItemId = 2, ItemName = "Sok" }, 10 },
                {new ShopItemData { ItemId = 3, ItemName = "Chleb" }, 10 }
            };


            _inventory = GetComponent<Inventory>();
            ShopItemListPanel.rectTransform.sizeDelta = new Vector2(0, 0);
            RedrawUi();
        }

        public void RedrawUi()
        {
            
            if (ShopItemToCollect != null && ShopItemToCollect.Count > 0)
            {
                foreach (Transform child in ShopItemListPanel.transform)
                {
                    Destroy(child.gameObject);
                }
                var currentYPos = Margin;
                var maxXPos = 0f;
                foreach (ShopItemData item in ShopItemToCollect.Keys)
                {
                    var text = Instantiate(TextPrefab);
                    text.transform.SetParent(ShopItemListPanel.transform, false);
                    text.GetComponent<RectTransform>().anchoredPosition = new Vector2(Margin,-currentYPos);
                    text.GetComponent<Text>().text = getStringForItem(item);
                    text.GetComponent<StrikethroughText>().Strikethrough = _inventory.GetAmountOfShopItemData(item) >=
                                                                           ShopItemToCollect[item];
                    currentYPos += text.GetComponent<Text>().preferredHeight;
                    maxXPos = maxXPos < text.GetComponent<Text>().preferredWidth ? text.GetComponent<Text>().preferredWidth :
                    maxXPos;

                }
                ShopItemListPanel.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, currentYPos + Margin);
                ShopItemListPanel.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxXPos + 2 * Margin);
            }
            else
            {
                ShopItemListPanel.rectTransform.sizeDelta = new Vector2(0,0);
            }
            
        }

        private string getStringForItem(ShopItemData item)
        {
            return String.Format("{1} {2}/{0}", ShopItemToCollect[item], item.ItemName, _inventory.GetAmountOfShopItemData(item));
        }
    }
}
