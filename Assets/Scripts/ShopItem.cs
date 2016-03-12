using UnityEngine;

namespace Assets.Scripts
{
    public class ShopItem : MonoBehaviour
    {
        public ShopItemData ShopItemData;

        private bool _isPlayer;

        // Use this for initialization
        void Start () {
    
        }
    
        // Update is called once per frame
        void Update () {
    
        }

        void OnTriggerStay(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                _isPlayer = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    other.SendMessage("AddItem", ShopItemData);
                    Destroy(gameObject);
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                _isPlayer = false;
            }
        }

        void OnGUI()
        {
            if (_isPlayer)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 20), "Press E to grab");
            }
        }
    }
}