using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(ShopItemList))]
    public class Inventory : MonoBehaviour
    {
        public Dictionary<ShopItemData, int> Items;

        private ShopItemList _shopItemList;

        // Use this for initialization
        void Start () {
            Items = new Dictionary<ShopItemData, int>();
            _shopItemList = GetComponent<ShopItemList>();
        }
    
        // Update is called once per frame
        void Update ()
        {
        }

        public void AddItem(ShopItemData item)
        {
            Debug.Log("Gathering item: " + item.ItemName);
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
    }
}
