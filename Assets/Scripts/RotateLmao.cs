using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLmao : MonoBehaviour {

    [Range(0f, 100f)] public float rotateSpeed;
    public Vector3 axis;
    void Start() {
        
    }

    void Update() {
        transform.Rotate(axis, rotateSpeed * Time.deltaTime);
    }
}
