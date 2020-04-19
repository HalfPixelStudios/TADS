using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BabyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    
    [SerializeField] private Vector3 target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target);
        if (agent.remainingDistance < 0.5)
        {
            GlobalContainer.Global.win();
            
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.attachedRigidbody.velocity.magnitude > 1)
        {
            Destroy(this);
            GlobalContainer.Global.dead();
            

        }
    }

    
    
        

}
