using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

//need to add a list of destinations
public class BabyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private List<Vector3> destinations;
    private int index;
    
    
    [SerializeField] private Vector3 target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destinations = destinations.OrderBy(a => Random.Range(0f,1f)).ToList();

    }

    // Update is called once per frame
    void Update()
    {
        //for death in water and manhole
        if (transform.position.y < -0.5f)
        {
            Destroy(this);
            GlobalContainer.Global.dead();
        }
        target = destinations[index];
        agent.SetDestination(target);
        if (agent.remainingDistance < 0.5)
        {
            index++;
            if (index == destinations.Count)
            {
                GlobalContainer.Global.win();
                
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.attachedRigidbody == null)
        {
            return;
        }
        if (other.collider.attachedRigidbody.velocity.magnitude > 1)
        {
            Destroy(this);
            GlobalContainer.Global.dead();
            

        }
    }

    
    
        

}
