using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(ShopItemList))]
    public class Inventory : MonoBehaviour
    {
        public Dictionary<ShopItemData, int> Items = new Dictionary<ShopItemData, int>();

        private ShopItemList _shopItemList;

        // Use this for initialization
        void Start () {
            _shopItemList = GetComponent<ShopItemList>();
        }
    
        // Update is called once per frame
        void Update ()
        {
        }

        public void AddItem(ShopItemData item)
        {
            if (!Items.ContainsKey(item))
            {
                Items.Add(item, 1);
            }
            else
            {
                Items[item]++;
            }
            _shopItemList.RedrawUi();
        }

        public int GetAmountOfShopItemData(ShopItemData item)
        {
            int value;
            return Items.TryGetValue(item, out value) ? value : 0;
        }

        public bool HasCollectedAllItems()
        {
            return _shopItemList.ShopItemToCollect.Keys.All(key => GetAmountOfShopItemData(key) >= _shopItemList.ShopItemToCollect[key]);
        }
    }
}
