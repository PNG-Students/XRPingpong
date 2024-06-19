using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBat : MonoBehaviour
{
    public float minVelocity = 1;
    public float maxVelocity = 20;

    public float hitThreshold = 0.5f;
    public float timeThresholdSeconds = 1f;

    public GameObject ball;

    public long lastHitInSeconds;

    public Transform hitPoint1;
    public Transform hitPoint2;
    public Transform centerPoint;

    public float power = 5f;

    DateTime? lastHitAt;
    private void Start()
    {
        StartCoroutine(ExecuteAfterDelay(5.0f));
    }

    private void Update()
    {
        if(ball != null)
        {
            if (Vector3.Distance(centerPoint.position, ball.transform.position) < hitThreshold)
            {
                if (lastHitAt == null || (DateTime.Now - lastHitAt.Value).TotalSeconds > timeThresholdSeconds)
                {
                    lastHitAt = DateTime.Now;
                    lastHitInSeconds = lastHitAt.Value.Ticks / 1000;

                    var distanceFromHitPoint1 = Vector3.Distance(hitPoint1.position, ball.transform.position);
                    var distanceFromHitPoint2 = Vector3.Distance(hitPoint2.position, ball.transform.position);

                    if (distanceFromHitPoint1 < distanceFromHitPoint2)
                    {
                        ball.GetComponent<Rigidbody>().velocity = hitPoint1.forward * power;
                    }
                    else
                    {
                        ball.GetComponent<Rigidbody>().velocity = hitPoint2.forward * power;
                    }
                    Debug.Log("Hit Ball");
                }
            }
            Debug.DrawRay(centerPoint.position, ball.transform.position - transform.position, Color.red);

            Debug.DrawRay(centerPoint.position, hitPoint1.forward, Color.blue);

            Debug.DrawRay(centerPoint.position, hitPoint2.forward, Color.green);
        }

    }

    private IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ball = GameObject.Find("PingPongBall(Clone)");
        //ball = GameObject.FindGameObjectWithTag("Ball");
        Debug.Log("Found Ball");


    }
}
