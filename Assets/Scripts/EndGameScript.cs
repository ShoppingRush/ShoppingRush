using UnityEngine;

namespace Assets.Scripts
{
    public class EndGameScript : MonoBehaviour {

        private bool _isPlayer;

        public Inventory Inventory;

        void OnTriggerStay(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                _isPlayer = true;
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
            if (_isPlayer && !GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenu>().IsPaused)
            {
                if (Inventory.HasCollectedAllItems())
                {
                    GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 20), "Koniec gry");
                }
                else
                {
                    GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 20), "Nie zebrałeś jeszcze wszystkich przedmiotów");
                }
            }
        }
    }
}
