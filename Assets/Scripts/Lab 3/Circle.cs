using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private float direction = 1;

    private float movespeed = 3;
    void Update()
    {
        Vector3 movement = new Vector3(x:direction, y:0f, z:0f);
        transform.Translate(movement * movespeed * Time.deltaTime);
        if (transform.position.x >= 3f || transform.position.x <= -3f)
        {
            direction *= -1;
        }
    }
}
