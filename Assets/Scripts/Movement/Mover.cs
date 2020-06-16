using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    [DisallowMultipleComponent]
    public class Mover : MonoBehaviour
    {
        //config
        [SerializeField] Transform target;
        public NavMeshAgent agent;
        Ray lastray;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            UpdateAnimator();

        }

        public void MoveTo(Vector3 destination)
        {
            agent.destination = destination;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}