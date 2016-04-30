using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Text))]
    public class ShowScore : MonoBehaviour
    {

        private Text _text;

        // Use this for initialization
        void Start ()
        {
            _text = GetComponent<Text>();
            _text.text = Timer.GetTimerText();
        }
    }
}
