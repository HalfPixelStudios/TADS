using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberController : PedestrianController {

    public float gunMaxRange;
    public override void DefaultBehavior() {
        base.DefaultBehavior();
    }

    public override void PossessedBehavior() {
        base.PossessedBehavior();
        
        //Shoot gun
        if (Input.GetKeyDown(KeyCode.P)) { //cast a ray and draw line until we hit something
            //Find direction and distance the gunshot should go
            Ray ray = new Ray(transform.position,facing);
            RaycastHit hit;
            Vector3 final = Vector3.zero;
            if (Physics.Raycast(ray,out hit,gunMaxRange)) { //if we hit something
                final = hit.collider.transform.position;

                /*
                float dist = Mathf.Sqrt(Mathf.Pow(offset.x,2)+ Mathf.Pow(offset.y, 2)+ Mathf.Pow(offset.z, 2));

                offset = (dist > gunMaxRange) ? offset * (gunMaxRange / dist) : offset; //if object we hit exceeds max range, set offset vector to length maxRange
                */
            } else { //if we didnt hit, set gun shot to max range
                final = transform.position + facing.normalized * gunMaxRange;  
            }

            Debug.DrawLine(transform.position,final,Color.yellow,3);
        }
    }
}
