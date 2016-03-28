using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Image))]
    public class StrikethroughText : MonoBehaviour
    {
        public Text Text;

        public bool Strikethrough;

        private Image _image;

        // Use this for initialization
        void Start()
        {
            _image = GetComponent<Image>();
            _image.rectTransform.sizeDelta = new Vector2(Text.preferredWidth, 3);
            _image.rectTransform.position = new Vector3(0, Text.preferredHeight);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnGUI()
        {
            _image.enabled = Strikethrough;
        }
    }
}