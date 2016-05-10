using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenu : MonoBehaviour
    {

        public void ExitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        public void SelectLevel()
        {
            SceneManager.LoadScene("SelectLevel");
        }

        public void StartGame()
        {
            SceneManager.LoadScene(Level.Level1.ToString());
        }
    }
}
