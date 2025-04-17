using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject brokenegg;

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Destroy(this.gameObject);
            var Effect = Instantiate(brokenegg,transform.position,Quaternion.identity);
            Destroy(Effect,0.3f);
        }
    }
}
