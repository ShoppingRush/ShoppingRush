using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Assets.Scripts
{
    public class Patrol : MonoBehaviour
    {

        private List<GameObject> _items;
        private GameObject _player;
        private NavMeshAgent _agent;
        private AICharacterControl _aiCharacterControl;
        private Animator _animator;


        void Start()
        {
            _animator = GetComponent<Animator>();
            _player = GameObject.FindGameObjectWithTag("Player");
            _items = new List<GameObject>(GameObject.FindGameObjectsWithTag("Item"));
            _agent = GetComponent<NavMeshAgent>();
            _aiCharacterControl = GetComponent<AICharacterControl>();
            _agent.autoBraking = false;
            _aiCharacterControl.SetTarget(_items[Random.Range(0, _items.Count - 1)].transform);
        }

        void Update()
        {
            if (_agent.enabled && _agent.remainingDistance < 5f)
            {
                _aiCharacterControl.SetTarget(_items[Random.Range(0, _items.Count - 1)].transform);
            }
        }
    }
}
