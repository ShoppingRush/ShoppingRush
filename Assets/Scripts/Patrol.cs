using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Assets.Scripts
{
    public class Patrol : MonoBehaviour
    {

        public List<GameObject> _items;
        private NavMeshAgent _agent;
        private AICharacterControl _aiCharacterControl;
        private Random _rnd;


        void Start()
        {
            _items = new List<GameObject>(GameObject.FindGameObjectsWithTag("Item"));
            _agent = GetComponent<NavMeshAgent>();
            _aiCharacterControl = GetComponent<AICharacterControl>();
            _agent.autoBraking = false;
            _aiCharacterControl.SetTarget(_items[Random.Range(0, _items.Count - 1)].transform);
        }

        void Update()
        {
            if (_agent.remainingDistance < 5f)
            {
                _aiCharacterControl.SetTarget(_items[Random.Range(0, _items.Count - 1)].transform);
            }
        }
    }
}
