using System;
using UnityEngine;

public class Player_Scr : MonoBehaviour {
    public float throttlePower;
    public float steeringSpeed;
    
    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private float throttle;
    private float steering;
    
    void Update() {
        throttle = Input.GetAxis("Vertical");
        steering = Input.GetAxis("Horizontal");
    }
    
    void FixedUpdate() {
        
        var force = Vector3.forward * throttle;
        force *= throttlePower;
        force *= Time.deltaTime;
        
        rb.AddRelativeForce(force);

        transform.RotateAround(transform.position, Vector3.up, steering * steeringSpeed * Time.deltaTime);
    }
}
