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
    Ray lastray;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        UpdateAnimator();
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }  
    }

    private void MoveToCursor()
    {
        //sets ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //sets ray hit
        RaycastHit hit;
        //sets hasHit flag
        bool hasHit = Physics.Raycast(ray, out hit);
        //if hit sent destination point
        if (hasHit)
        {
            agent.destination = hit.point;
        }
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
