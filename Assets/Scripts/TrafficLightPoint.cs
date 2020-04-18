using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrafficLightPoint : WayPoint
{
    public enum TrafficLight
    {
        RED,
        GREEN
    };
    

    private List<PathAI> listeners=new List<PathAI>();
    

    public TrafficLight state = TrafficLight.RED;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void setNextNode(PathAI pathAi)
    {
        if (state == TrafficLight.RED)
        {
            listeners.Add(pathAi);
            
        }
        else
        {
            base.setNextNode(pathAi);
        }
        
        
    }

    public void setState(TrafficLight tl)
    {
        state = tl;
        if (state == TrafficLight.GREEN)
        {
            foreach (var pathAi in listeners)
            {
                base.setNextNode(pathAi);
                
            }

            listeners=new List<PathAI>();
        }
    }
}
