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
    private void Start()
    {
        // print the path to the temporary data folder
        print(Application.temporaryCachePath)
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }


    // Update is called once per frame
    void Update()
    {
    }
}
