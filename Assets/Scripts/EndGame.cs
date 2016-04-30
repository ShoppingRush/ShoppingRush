using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Scripts
{
    public class EndGame : MonoBehaviour {

        private bool _isPlayer;

        public Inventory Inventory;

        public GameObject EndGamePanel;

        public PauseMenu PauseMenu;

        public FirstPersonController FirstPersonController;

        public Timer Timer;

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
            if (_isPlayer && !PauseMenu.IsPaused)
            {
                if (Inventory.HasCollectedAllItems())
                {
                    SceneManager.LoadScene("EndGame");
                }
                else
                {
                    // TODO improve this
                    GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 20), "Nie zebrałeś jeszcze wszystkich przedmiotów");
                }
            }
        }
    }
}
