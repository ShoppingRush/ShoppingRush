using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Assets.Scripts
{
    public class Patrol : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private AICharacterControl _aiCharacterControl;
        private GameObject _player;

        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _agent = GetComponent<NavMeshAgent>();
            _aiCharacterControl = GetComponent<AICharacterControl>();
            _agent.autoBraking = false;
        }

        void Update()
        {
            if (_agent.enabled && _agent.remainingDistance < 5f)
            {
                var items = new List<GameObject>(GameObject.FindGameObjectsWithTag("Item"));
                _aiCharacterControl.SetTarget(items[Random.Range(0, items.Count - 1)].transform);
            }
        }
    }
}
