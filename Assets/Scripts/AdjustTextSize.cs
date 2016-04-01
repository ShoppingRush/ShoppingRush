using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Text))]
    public class AdjustTextSize : MonoBehaviour
    {
        private Text _text;
        private RectTransform _rectTransform;

        // Use this for initialization
        void Start ()
        {
            _text = GetComponent<Text>();
            _rectTransform = GetComponent<RectTransform>();
        }
    
        // Update is called once per frame
        void Update () {
            _rectTransform.sizeDelta = new Vector2(_text.preferredWidth, _text.preferredHeight);
        }
    }
}
