using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private int count;
    public GameObject egg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count > 1200)
        {
            Instantiate(egg, transform.position,Quaternion.identity);
            count = 0;
        }
    }
}
