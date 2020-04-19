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
        var c = connections;
        
        if (pathAi.prevNode != null)
        {
            print(pathAi.prevNode);
            c = connections.FindAll(node => node.transform.position!=pathAi.prevNode.transform.position);
            
        }

        pathAi.prevNode = pathAi.node;
        print(c.Count);
        pathAi.node=c[Random.Range(0, c.Count)];
        pathAi.setTarget();
    }
}
