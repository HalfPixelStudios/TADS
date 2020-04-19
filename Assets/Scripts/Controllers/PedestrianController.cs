using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianController : Possesable
{
    private PathAI _pathAi;
    private Rigidbody rb;
    [SerializeField]private float speed;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _pathAi = GetComponent<PathAI>();
        anim = GetComponent<Animator>();



    }
    public override void DefaultBehavior()
    {
        if (_pathAi.target != null)
        {
            anim.SetBool("moving",true);
            transform.LookAt(_pathAi.target);
            var angles = transform.rotation.eulerAngles;
            transform.rotation=Quaternion.Euler(0,angles.y,0);
            
            transform.position+= transform.forward * speed;
            
        }
        else
        {
            anim.SetBool("moving",false);
        }
        
        
        
        
    }

    public override void PossessedBehavior()
    {

        float turn = Input.GetAxis("Horizontal");
        float dir = Input.GetAxis("Vertical");
        if (dir == 0)
        {
            anim.SetBool("moving",false);
            
        }
        else
        {
            anim.SetBool("moving",true);
        }
        
        rb.angularVelocity=new Vector3(0,turn*20,0);
        transform.position+= dir * transform.forward * speed;
        print(rb.velocity);

    }
    
}
