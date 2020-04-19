using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GlobalContainer;

public abstract class Possesable : MonoBehaviour {

    public bool isPossessed;

    void Update() {
        if (isPossessed) {
            PossessedBehavior();
        } else {
            DefaultBehavior();
        }
        AnyBehavior();
    }

    public virtual void DefaultBehavior() { }
    public virtual void PossessedBehavior() { }
    public virtual void AnyBehavior() { }

    public virtual void OnPossess() {
        
    }


}

