using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class EndGameMenu : MonoBehaviour {

        public void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void PlayAgain()
        {
            SceneManager.LoadScene(SelectLevelMenu.CurrentLevel);
        }

        public void NextLevel()
        {
            var currentLevel = (Level) Enum.Parse(typeof (Level), SelectLevelMenu.CurrentLevel);
            currentLevel++;
            SceneManager.LoadScene(currentLevel.ToString());
        }
    }
}
