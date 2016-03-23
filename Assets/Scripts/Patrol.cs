using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Assets.Scripts
{
    public class Patrol : MonoBehaviour
    {

        public List<Transform> Points;
        private int _destPoint = 0;
        private NavMeshAgent _agent;
        private AICharacterControl _aiCharacterControl;


        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _aiCharacterControl = GetComponent<AICharacterControl>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            _agent.autoBraking = false;
            GotoNextPoint();
        }


        void GotoNextPoint()
        {
            // Returns if no points have been set up
            if (Points.Count == 0)
                return;

            // Set the agent to go to the currently selected destination.
            _aiCharacterControl.SetTarget(Points[_destPoint]);
            //_agent.destination = Points[_destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            _destPoint = (_destPoint + 1) % Points.Count;
        }


        void Update()
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (_agent.remainingDistance < 1f)
            {
                GotoNextPoint();
            }
        }
    }
}
