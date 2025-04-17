using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    private Rigidbody2D rb;
    private Animator animator;
    private int score = 0;
    public TMP_Text Score;
    public Slider slider;
    public float MaxHealth;
    public AudioSource mainAudio;
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Score.text = "Score: " + score;
        slider.maxValue = MaxHealth;
        slider.value = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(horizontal) > Mathf.Epsilon)
        {
            animator.SetBool("is running",true);
            rb.velocity = new Vector2(horizontal * movespeed, rb.velocity.y);
            var rotation_y = (horizontal > 0.1f) ? 0 : -180;
            transform.rotation = Quaternion.Euler(new Vector3(0, rotation_y, 0));
        }
        else
        {
            animator.SetBool("is running", false);
            rb.velocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("egg"))
        {
            Destroy(other.attachedRigidbody.gameObject);
            score++;
            Score.text = "Score: " + score;
            slider.value =  slider.value - 1;
            if (slider.value == slider.minValue)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void isCheck()
    {
        if (toggle.isOn)
        {
            mainAudio.Play();
            Debug.Log("da bat audio");
        }
        else if (!toggle.isOn)
        {
            mainAudio.Stop();
            Debug.Log("da tat audio");
        }
    }
}