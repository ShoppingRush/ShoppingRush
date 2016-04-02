using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class SelectLevelMenu : MonoBehaviour
    {
        private string _activeLevel;

        private Image _levelImage;

        private Button _playButton;

        public void Start()
        {
            _playButton = GameObject.Find("PlayButton").GetComponent<Button>();
            _levelImage = GameObject.Find("LevelImage").GetComponent<Image>();
            _playButton.interactable = false;
        }

        public void BackToMenu()
        {
            LoadLevel("MainMenu");
        }

        private void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

        public void SelectLevel(string levelName)
        {
            _playButton.interactable = true;
            _activeLevel = levelName;
        }

        public void ShowImage(Sprite image)
        {
            _levelImage.sprite = image;
        }

        public void StartSelectedLevel()
        {
            LoadLevel(_activeLevel);
        }
    }
}
