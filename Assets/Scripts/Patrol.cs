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

        private GameObject _player;

        private float _timer;

        private NavMeshAgent _agent;

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

            _player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            _timer += Time.deltaTime;

            if ((_timer >= PatrolTimer || _agent.remainingDistance < 0.5) && GetLevel() != Level.Stair)
            {
                Vector3 newPos = RandomNavCircle(_player.transform.position, PatrolRadius, NavMesh.AllAreas);
                _agent.SetDestination(newPos);
                _timer = 0;
            }

            switch (GetLevel())
            {
                case Level.Upstair:
                    _navMeshAgent.areaMask = NavMesh.AllAreas ^ 1 << NavMesh.GetAreaFromName("StairUp");
                    break;
                case Level.Downstair:
                    _navMeshAgent.areaMask = NavMesh.AllAreas ^ 1 << NavMesh.GetAreaFromName("StairDown");
                    break;
                case Level.Stair:
                    _navMeshAgent.areaMask = NavMesh.AllAreas;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Vector3 RandomNavCircle(Vector3 origin, float dist, int layermask)
        {
            Vector3 randDirection = Random.insideUnitSphere * dist;
            randDirection += origin;
            NavMeshHit navHit;

            NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
            return navHit.position;
        }

        private Level GetLevel()
        {
            if (transform.position.y < 0.55f)
            {
                return Level.Downstair;
            }
            if (transform.position.y > 4.45f)
            {
                return Level.Upstair;
            }
            return Level.Stair;
        }
    }

    internal enum Level
    {
        Upstair,
        Downstair,
        Stair
    }

}

