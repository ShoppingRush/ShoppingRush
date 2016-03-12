using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Inventory : MonoBehaviour
    {
        public List<ShopItemData> Items;

        // Use this for initialization
        void Start () {
    
        }
    
        // Update is called once per frame
        void Update () {
    
        }

        public void AddItem(ShopItemData item)
        {
            Debug.Log("Gathering item: " + item.ItemName);
            Items.Add(item);
        }
    }
}
