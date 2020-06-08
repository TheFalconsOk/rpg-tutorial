using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class Mover : MonoBehaviour
{
    //config
    [SerializeField] Transform target;
    public NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        if (agent.destination != target.position)
        {
            agent.destination = target.position;
        }   
    }
}
