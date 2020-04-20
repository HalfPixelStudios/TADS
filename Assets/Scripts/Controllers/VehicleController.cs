using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

public class VehicleController : Possesable
{
    // Start is called before the first frame update
    private PathAI _pathAi;
    private Rigidbody rb;

    //public 
    public float speed;
    public float turnSpeed;
    public float accel; //acceleration/brake increment
    public float brake;
    public float decay; //slow down due to friction
    public float maxFwdSpeed;
    public float maxBkdSpeed;
    public float stoppingDistance;

    private float curVelo;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _pathAi = GetComponent<PathAI>();


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

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.rigidbody.velocity.magnitude + rb.velocity.magnitude > 1)
        {
            ParticleSystem fire = Instantiate(Global.fire,transform);
            fire.Play();
            if (isPossessed)
            {
                Global.possesor.SetPossessed(Camera.main.GetComponent<Possesable>());
            }
            Destroy(this);
        }
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<VehicleController>() != null)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public override void PossessedBehavior() {

        Vector2 inp = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //forward movement
        if (inp.y > 0) { curVelo += accel; }
        else if (inp.y < 0) { curVelo -= brake; }

        if (curVelo != 0) {
            curVelo -= (curVelo / Mathf.Abs(curVelo) * decay); //apply 'friction' in the opposite direction of motion
        }

        curVelo = Mathf.Clamp(curVelo, -maxBkdSpeed, maxFwdSpeed);

        //turning
        float turnScale = 0; //you can only turn better at higher speeds
        if (curVelo > 0) {
            turnScale = curVelo / maxFwdSpeed;
        } else if (curVelo < 0) {
            turnScale = -curVelo / maxBkdSpeed;
        }
        transform.Rotate(Vector3.up,turnSpeed*inp.x*Time.deltaTime*turnScale);

        //move car
        rb.velocity=curVelo * transform.forward * Time.deltaTime;


        /*        
        rb.angularVelocity=new Vector3(0,turn*5,0);
        print(transform.forward);
        rb.velocity = dir * transform.forward * speed*5;
        */
    }

    public override void AnyBehavior() {
        
    }
}
