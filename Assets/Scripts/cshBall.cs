using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBall : MonoBehaviour
{
    public float strength = 4;

    public float maxSpeed = 5f;

    public float minVelocity = 3;
    public float maxVelocity = 7;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, maxSpeed);
    } 
}
