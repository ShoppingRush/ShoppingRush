using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SelectLevelMenu : MonoBehaviour {
        public void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
