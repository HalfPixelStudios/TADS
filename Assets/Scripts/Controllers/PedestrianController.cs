using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GlobalContainer;

public class PedestrianController : Possesable
{
    private PathAI _pathAi;
    private Rigidbody rb;
    [SerializeField]private float speed;
    private Animator anim;
    public float stoppingDistance;

    protected Vector3 facing = new Vector3(1,0,1);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _pathAi = GetComponent<PathAI>();
        anim = GetComponent<Animator>();


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
            anim.SetBool("moving",true);
            

            transform.LookAt(_pathAi.target);
            var angles = transform.rotation.eulerAngles;
            transform.rotation=Quaternion.Euler(0,angles.y,0);
            transform.position+= transform.forward * speed * Time.deltaTime;
            

        }
        else
        {
            anim.SetBool("moving",false);
        }
        
        
        
        
        
        
    }

    public override void PossessedBehavior() {

        Vector2 inp = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        //Move in the direction the camera is 
        Vector3 forward = new Vector3(Global.captureCam.transform.forward.x, 0, Global.captureCam.transform.forward.z).normalized;

        Vector3 move = (inp.x * Global.captureCam.transform.right + inp.y * forward) * speed * Time.deltaTime;

        transform.position += move;

        if (inp != Vector2.zero) { //facing in direction of movement
            facing = move;
            transform.rotation = Quaternion.LookRotation(facing); //look in direction cam is facing
        }

        

        //Animation stuff
        anim.SetBool("moving", inp != Vector2.zero);


        /*
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
        */

    }
    
}
