﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAI : MonoBehaviour
{
    public Vector3 target;

    public WayPoint node;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called by waypoints
    public void setTarget()
    {
        this.target = new Vector3(node.transform.position.x,0,node.transform.position.z);
    }

    //called by controller
    public void setNextNode()
    {
        node.setNextNode(this);
    }

    
}
