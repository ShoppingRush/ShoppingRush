using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Toggle))]
    public class SelectLevelButton : MonoBehaviour
    {
        public SelectLevelMenu SelectLevelMenu;

        public string LevelName;

        public Sprite LevelImage;

        private Toggle _toggle;

        // Use this for initialization
        void Start ()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(value =>
            {
                _toggle.interactable = !value;
                SelectLevelMenu.SelectLevel(LevelName);
                SelectLevelMenu.ShowImage(LevelImage);
            });
        }
    }
}
