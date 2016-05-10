using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Button))]
    public class NextLevelButton : MonoBehaviour
    {
        private Button _nextLevelButton;

        // Use this for initialization
        void Start ()
        {
            _nextLevelButton = GetComponent<Button>();
            if ((Level)Enum.Parse(typeof (Level), SelectLevelMenu.CurrentLevel) == Level.Level2)
            {
                _nextLevelButton.interactable = false;
            }
        }
    }
}
