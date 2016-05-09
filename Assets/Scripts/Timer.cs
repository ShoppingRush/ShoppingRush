using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        public static float Seconds = 0;

        public Text TimerText;

        public Text CountdownText;

        public FirstPersonController FirstPersonController;

        public bool Countdown = true;


        // Use this for initialization
        void Start ()
        {
            Seconds = 0;
            Countdown = true;
            var rectTransfort = TimerText.GetComponent<RectTransform>();
            var textHeight = (int)(Screen.height * 0.1f);
            if (textHeight < 10)
            {
                textHeight = 10;
            }
            rectTransfort.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textHeight);
            rectTransfort.anchoredPosition = new Vector2(0, -textHeight / 2);
            StartCoroutine(CountdownTimer());
            Cursor.visible = false;
        }

        public void OnPause(bool pause)
        {
            if (Countdown)
            {
                CountdownText.enabled = !pause;
            }
        }
    
        // Update is called once per frame
        void Update ()
        {
            if (!Countdown)
            {
                Seconds += Time.deltaTime;
                TimerText.text = GetTimerText();
            }
        }

        public static string GetTimerText()
        {
            var minutes = (int)Seconds / 60;
            var seconds = (int)Seconds % 60;
            var fraction = (int)(Seconds * 100) % 100;
            return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
        }

        private IEnumerator CountdownTimer()
        {
            Countdown = true;
            var countdownValue = 3;
            CountdownText.text = string.Empty;
            CountdownText.enabled = true;
            FirstPersonController.enabled = false;
            while (countdownValue > 0)
            {
                CountdownText.text = string.Format("{0:0}", countdownValue);
                countdownValue--;
                yield return new WaitForSeconds(1);
            }
            FirstPersonController.enabled = true;
            CountdownText.text = "START!";
            yield return new WaitForSeconds(0.75f);
            Countdown = false;
            CountdownText.enabled = false;
        }
    }
}
