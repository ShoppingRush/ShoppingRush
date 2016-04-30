using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        public static float Seconds = 0;

        private Text _text;
        private RectTransform _rectTransfort;


        // Use this for initialization
        void Start ()
        {
            Seconds = 0;
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
            Seconds += Time.deltaTime;

            _text.text = GetTimerText();
        }

        public static string GetTimerText()
        {
            var minutes = (int)Seconds / 60;
            var seconds = (int)Seconds % 60;
            var fraction = (int)(Seconds * 100) % 100;
            return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
        }
    }
}
