using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai4 : MonoBehaviour
{
    public Transform targetObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = targetObject.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }
}
