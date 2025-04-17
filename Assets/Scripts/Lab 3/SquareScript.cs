using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SquareScript : MonoBehaviour
{
    public float speed = 5.0f;
    private int score = 0;
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {
            Vector2 firstposition = new Vector2(x: -6.6f, y: 2.4f);
            transform.position = firstposition;
        }
        if (collision.gameObject.tag.Equals("box"))
        {
            SceneManager.LoadScene("Lab 4");
            GameManager.instance.score = 3;
        }
        if (collision.gameObject.tag.Equals("box2"))
        {
            if (GameManager.instance.score == 0)
            {
                SceneManager.LoadScene("Lab 4(2)");
                GameManager.instance.score = 4;
            }
        }
        if (collision.gameObject.tag.Equals("box3"))
        {
            if (GameManager.instance.score == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        if (collision.gameObject.CompareTag("point"))
        {
            Destroy(collision.attachedRigidbody.gameObject);
            if (GameManager.instance.score > 0)
            {
                GameManager.instance.score--;
            }
        }
    }
}
