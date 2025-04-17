using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Enemy movement speed
    private Transform player;  // Reference to the player
    private bool facingRight = true;  // Track whether the enemy is facing up or down

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  // Find the player by tag
    }

    private void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Flip sprite based on player's X position
            if (direction.x > 0 && !facingRight)
            {
                FlipX();
            }
            else if (direction.x < 0 && facingRight)
            {
                FlipX();
            }
        }
    }

    void FlipX()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;  // Flip the X axis
        transform.localScale = theScale;
    }
}
