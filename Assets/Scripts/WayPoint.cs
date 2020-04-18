using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    public List<WayPoint> connections = new List<WayPoint>();
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public virtual Vector2 GetPosition()
    {
        return new Vector2(transform.position.x,transform.position.z);
    }

    public virtual void setNextNode(PathAI pathAi)
    {
        pathAi.node=connections[Random.Range(0, connections.Count)];
        pathAi.setTarget();
    }
}
