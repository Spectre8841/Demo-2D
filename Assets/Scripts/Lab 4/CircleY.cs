using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleY : MonoBehaviour
{
    private float direction = 1;

    private float movespeed = 3;
    void Update()
    {
        Vector3 movement = new Vector3(0, direction, 0);
        transform.Translate(movement * movespeed * Time.deltaTime);
        if (transform.position.y >= 4.5f || transform.position.y <= 0f)
        {
            direction *= -1;
        }
    }
}
