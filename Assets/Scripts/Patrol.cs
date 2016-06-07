using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Patrol : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;

        public float PatrolRadius;

        public float PatrolTimer;

        private float _timer;

        private NavMeshAgent _agent;

        private FloorLevel _latestLevel;

        public Patrol(float timer)
        {
            _timer = timer;
        }

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.autoBraking = false;
            _timer = PatrolTimer;
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _latestLevel = GetLevel();
        }

        // Update is called once per frame
        void Update()
        {
            var currentLevel = GetLevel();
            _timer += Time.deltaTime;

            if ((_timer >= PatrolTimer || _agent.remainingDistance < 0.5) && currentLevel != FloorLevel.Stair)
            {
                var items = new List<GameObject>(GameObject.FindGameObjectsWithTag("Item")); // TODO improve this
                if (items.Count > 0)
                {
                    var newPos = RandomNavSphere(items[Random.Range(0, items.Count - 1)].transform.position,
                        PatrolRadius, NavMesh.AllAreas);
                    _agent.SetDestination(newPos);
                }
                else
                {
                    var newPos = RandomNavSphere(Vector3.zero, 
                        PatrolRadius, NavMesh.AllAreas);
                    _agent.SetDestination(newPos);
                }
                _timer = 0;
            }

            if (_latestLevel != currentLevel)
            {
                switch (currentLevel)
                {
                    case FloorLevel.Upstair:
                        _navMeshAgent.areaMask = NavMesh.AllAreas ^ 1 << NavMesh.GetAreaFromName("StairUp");
                        break;
                    case FloorLevel.Downstair:
                        _navMeshAgent.areaMask = NavMesh.AllAreas ^ 1 << NavMesh.GetAreaFromName("StairDown");
                        break;
                    case FloorLevel.Stair:
                        _navMeshAgent.areaMask = NavMesh.AllAreas;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            _latestLevel = currentLevel;
            
        }

        public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
        {
            Vector3 randDirection = Random.insideUnitSphere * dist;
            randDirection += origin;
            NavMeshHit navHit;

            NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
            return navHit.position;
        }

        private FloorLevel GetLevel()
        {
            if (transform.position.y < 0.55f)
            {
                return FloorLevel.Downstair;
            }
            if (transform.position.y > 4.45f)
            {
                return FloorLevel.Upstair;
            }
            return FloorLevel.Stair;
        }
    }

    internal enum FloorLevel
    {
        Upstair,
        Downstair,
        Stair
    }

}

