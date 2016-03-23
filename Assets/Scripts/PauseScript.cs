using System;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Scripts
{
    public class PauseScript : MonoBehaviour
    {

        public bool IsPaused = false;

        public GameObject PauseMenu;
    
        // Update is called once per frame
        void Update ()
        {
            if (Input.GetButtonDown("Pause"))
            {
                IsPaused = true;
            }
            (GameObject.Find("FPSController").GetComponent("FirstPersonController") as MonoBehaviour).enabled = !IsPaused;
            Time.timeScale = IsPaused ? 0 : 1;
            PauseMenu.SetActive(IsPaused);
            Cursor.visible = IsPaused;
            Cursor.lockState = CursorLockMode.None;
        }

        public void OnContinueButtonClick()
        {
            IsPaused = false;
        }
    }
}
