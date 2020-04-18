using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : Possesable
{
    // Start is called before the first frame update
    private PathAI _pathAi;
    private Rigidbody rb;
    [SerializeField]private float speed;
    [SerializeField]private float stoppingDistance;
    public bool stopTrigger;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _pathAi = GetComponent<PathAI>();
        _pathAi.setTarget();


    }
    
    public override void DefaultBehavior()
    {
        float d = Vector3.Distance(transform.position, _pathAi.target);
        if (d < stoppingDistance)
        {
            _pathAi.setNextNode();
        }
        if (_pathAi.target != null)
        {

            transform.LookAt(_pathAi.target);
            rb.velocity = transform.forward * speed;
            

        }
        
        
    }

    public override void PossessedBehavior()
    {
        throw new System.NotImplementedException();
    }
}
