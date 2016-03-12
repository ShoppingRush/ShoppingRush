using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        private float _seconds = 0;

        private Text _text;
        private RectTransform _rectTransfort;

        // Use this for initialization
        void Start ()
        {
            _text = GetComponent<Text>();
            _rectTransfort = GetComponent<RectTransform>();
            var textHeight = (int)(Screen.height * 0.1f);
            if (textHeight < 10)
            {
                textHeight = 10;
            }
            _rectTransfort.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textHeight);
            _rectTransfort.anchoredPosition = new Vector2(0, -textHeight / 2);
        }
    
        // Update is called once per frame
        void Update ()
        {
            _seconds += Time.deltaTime;
            var minutes  = (int)_seconds / 60;
            var seconds  = (int)_seconds % 60;
            var fraction = (int)(_seconds * 100) % 100;

            _text.text = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
        }
    }
}
