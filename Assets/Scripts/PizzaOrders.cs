using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

//need to add a list of destinations
public class PizzaOrders : MonoBehaviour
{
    [SerializeField] private List<Vector3> destinations;
    private int index=0;
    
    
    [SerializeField] private Vector3 target;
    void Start()
    {
        destinations = destinations.OrderBy(a => Random.Range(0f,1f)).ToList();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target, transform.position) < 2)
        {
            index += 1;
            if (index > destinations.Count)
            {
                GlobalContainer.Global.win();
            }
            target = destinations[index];
        }
        
    }
    

    
    
        

}
