using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Text))]
    public class StrikethroughText : MonoBehaviour
    {
        public GameObject Image;

        public bool Strikethrough;

        private Image _image;
        private RectTransform _rectTransform;
        private Text _text;

        // Use this for initialization
        void Start()
        {
            _image = Image.GetComponent<Image>();
            _rectTransform = Image.GetComponent<RectTransform>();
            _text = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            _rectTransform.sizeDelta = new Vector2(_text.preferredWidth, _text.preferredHeight > 10 ? 0.1f * _text.preferredHeight : 1);
            _rectTransform.anchoredPosition = new Vector3(0, 0);
        }

        void OnGUI()
        {
            _image.enabled = Strikethrough;
        }
    }
}
