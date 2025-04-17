using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 5.0f;
    private float currentHealth;
    private Animator animator;
    private float damageCooldown = 1.0f;
    private float lastDamageTime;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);  // Destroy the enemy object
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsAttack", true);
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);  // Player takes damage
                lastDamageTime = Time.time;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsAttack", false);  // Reset the attack animation when the player exits the trigger
        }
    }
}
