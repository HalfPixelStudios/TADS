using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

public class ShipController : VehicleController
{
    public float range;
    public GameObject cannonBall;
    public float ballSpeed;

    public float shotInterval;
    public float timer;
    
    public override void DefaultBehavior()
    {
        timer += Time.deltaTime;
        if (timer > shotInterval)
        {
            if (Vector3.Distance(Global.baby.transform.position, transform.position) < range)
            {
                GameObject c = Instantiate(cannonBall, transform.position, Quaternion.identity);
                c.transform.LookAt(Global.baby.transform);
                c.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;


            }

            timer = 0;

        }
        
        

    }

    
    
}
