using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        public bool IsPaused = false;

        public GameObject PauseMenuPanel;

        public FirstPersonController FirstPersonController;

        public Timer Timer;

        void Start()
        {
            var rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var rootObject in rootObjects)
            {
                rootObject.BroadcastMessage("OnPause", IsPaused, SendMessageOptions.DontRequireReceiver);
            }
        }
    
        // Update is called once per frame
        void Update ()
        {
            if (Input.GetButtonDown("Pause") && !Timer.Countdown)
            {
                IsPaused = true;
                var rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
                foreach (var rootObject in rootObjects)
                {
                    rootObject.BroadcastMessage("OnPause", IsPaused, SendMessageOptions.DontRequireReceiver);
                }
                FirstPersonController.enabled = !IsPaused;
                Time.timeScale = IsPaused ? 0 : 1;
                PauseMenuPanel.SetActive(IsPaused);
                Cursor.visible = IsPaused;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        public void Continue()
        {
            IsPaused = false;
            FirstPersonController.enabled = !IsPaused;
            Time.timeScale = IsPaused ? 0 : 1;
            PauseMenuPanel.SetActive(IsPaused);
            Cursor.visible = IsPaused;
            Cursor.lockState = CursorLockMode.None;
            var rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var rootObject in rootObjects)
            {
                rootObject.BroadcastMessage("OnPause", IsPaused, SendMessageOptions.DontRequireReceiver);
            }
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void ExitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SelectLevelMenu.CurrentLevel);
        }
    }
}
