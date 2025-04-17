using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lab4 : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private void Update()
    {
        RotateObject();
    }
    private void RotateObject()
    {
        float currentangle = transform.rotation.eulerAngles.z;

        float newAngle = currentangle + (rotationSpeed * Time.deltaTime);

        Quaternion newRotation = Quaternion.Euler(0, 0, newAngle);

        transform.rotation = newRotation;
    }
}
