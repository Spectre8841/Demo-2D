using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smolball : MonoBehaviour
{
    public Transform center; // The center point of the circle
    public float radius = 5.0f; // The radius of the circle
    public float angularSpeed = 2.0f; // The speed at which the ball moves around the circle

    private float angle = 0.0f; // The current angle in radians

    void Update()
    {
        // Increase the angle based on the angular speed and time elapsed
        angle += angularSpeed * Time.deltaTime;

        // Calculate the new position of the ball
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        // Set the new position relative to the center point
        transform.position = new Vector3(x, y, 0) + center.position;
    }
}
