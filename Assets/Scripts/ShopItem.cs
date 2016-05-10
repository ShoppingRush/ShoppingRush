using UnityEngine;

namespace Assets.Scripts
{
    public class ShopItem : MonoBehaviour
    {
        public ShopItemData ShopItemData;

        private bool _isPlayer;
        private bool _pause;

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
                    other.GetComponent<Inventory>().AddItem(ShopItemData);
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

//        void OnGUI()
//        {
//            if (_isPlayer && !_pause)
//            {
//                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 20), "Press E to grab");
//            }
//        }

        public void OnPause(bool pause)
        {
            _pause = pause;
        }
    }
}
