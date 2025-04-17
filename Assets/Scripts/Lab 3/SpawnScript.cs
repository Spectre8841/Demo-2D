using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject enemySpawn;

    public GameObject player;

    private int count = 0;

    [SerializeField] private float movespeed;

    public float destroyAfterSeconds = 5.0f;

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count > 1200)
        {
            GameObject spawn = Instantiate(enemySpawn, transform.position, Quaternion.identity);

            Vector3 dir = (player.transform.position - spawn.transform.position).normalized;
            
            spawn.GetComponent<Rigidbody2D>().velocity = dir * movespeed;

            Destroy(spawn, destroyAfterSeconds);

            count = 0;
        }
    }
}
