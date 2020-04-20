using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberController : PedestrianController {
    public override void DefaultBehavior() {
        base.DefaultBehavior();
    }

    public override void PossessedBehavior() {
        base.PossessedBehavior();
        
        //Shoot gun
    }
}
