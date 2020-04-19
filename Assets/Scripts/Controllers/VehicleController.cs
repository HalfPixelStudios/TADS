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
        if (_pathAi.target != Vector3.zero)
        {
            

            transform.LookAt(_pathAi.target);
            var angles = transform.rotation.eulerAngles;
            transform.rotation=Quaternion.Euler(0,angles.y,0);
            
            rb.velocity = transform.forward * speed;
            

        }
        else
        {
            rb.velocity=Vector3.zero;
        }
        
        
    }

    public override void PossessedBehavior()
    {
        float turn = Input.GetAxis("Horizontal");
        float dir = Input.GetAxis("Vertical");
        
        rb.angularVelocity=new Vector3(0,turn,0);
        rb.AddForce(dir*transform.forward*speed);
    }

    public override void AnyBehavior() {
        
    }
}
