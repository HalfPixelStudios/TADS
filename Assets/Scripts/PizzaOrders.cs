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
    [SerializeField] private List<Transform> destinations;
    private int index=0;
    
    
    void Start()
    {
        destinations = destinations.OrderBy(a => Random.Range(0f,1f)).ToList();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target=Vector3.zero;
        foreach (var t in destinations)
        {

            if (Vector3.Distance(t.position, transform.position) < 1)
            {
                target = t.position;
                destinations.Remove(t);
                break;

            }
            
        }
        
        
        if(target!=Vector3.zero)
        {
            Instantiate(GlobalContainer.Global.pizza, target, Quaternion.identity);
            GlobalContainer.Global.timer = 0;
            if (destinations.Count==0)
            {
                GlobalContainer.Global.win();
            }
        }
        
    }
    

    
    
        

}
