using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.0f;
    public LayerMask enemyLayer;
    public float damage = 1.0f;
    public AudioSource attackSource;
    private int score = 0;
    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))  // Press J to attack
        {
            Attack();
        }
    }

    void Attack()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        attackSource.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            score++;
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        //if (score == 3)
        //{
        //    player.transform.localScale = new Vector3(5,5,5);
        //}
        if (score == 20)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
