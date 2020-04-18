using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SelectableObject : MonoBehaviour {

    private void OnMouseDown() {
        Debug.Log("clicked!");
    }
}
