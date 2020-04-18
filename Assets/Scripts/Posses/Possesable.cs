using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ControlType {

}

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

    public abstract void DefaultBehavior();
    public abstract void PossessedBehavior();
    public abstract void AnyBehavior();

}

