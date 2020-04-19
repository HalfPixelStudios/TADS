using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAI : MonoBehaviour
{
    public Vector3 target;

    public WayPoint node;
    public WayPoint prevNode;

    // Start is called before the first frame update
    void Start()
    {
        setTarget();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called by waypoints
    public void setTarget()
    {
        if (node == null)
        {
            target = Vector3.zero;
            return;
        }
        
        this.target = new Vector3(node.transform.position.x,0,node.transform.position.z);
    }

    //called by controller
    public void setNextNode()
    {
        
        node.setNextNode(this);
        
    }

    
}
