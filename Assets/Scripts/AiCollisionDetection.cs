using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Scripts
{
    public class AiCollisionDetection : MonoBehaviour {
        void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                other.gameObject.GetComponent<FirstPersonController>().IsCollision = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                other.gameObject.GetComponent<FirstPersonController>().IsCollision = false;
            }
        }
    }
}
