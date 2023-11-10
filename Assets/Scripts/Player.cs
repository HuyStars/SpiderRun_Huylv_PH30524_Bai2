using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public ParticleSystem mat;
    public AudioSource death;
    public AudioSource coin;
    public AudioSource jump;
    public AudioSource boms;
    public int score = 0;
    public Text textMetter;
    public Text textScore;
    public Text Metter;
    public Text Score;
    public GameObject panelGameOver;
    
    private float distanceTraveled = 0.0f; // Khoảng cách nhân vật đã di chuyển
    private float lastXPosition; // Vị trí của nhân vật trong khung hình trước đó
    
    private Animator anim;
    private Rigidbody2D rb;

    public float jumpHeight = 8f;
    private bool grounded;
    private int jumpCount = 0;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        textScore.text = ""+score;
        textMetter.text = ""+(int)distanceTraveled;
        lastXPosition = transform.position.x;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump.Play();
            anim.SetBool("jump", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumpCount++;
        }else if (jumpCount < 2 && Input.GetKeyDown(KeyCode.Space))
        {
            jump.Play();
            anim.SetTrigger("doublejump");
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumpCount++;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("jump", false);
        }
        
        // Tính toán khoảng cách nhân vật đã di chuyển trên trục x
        float deltaX = Mathf.Abs(transform.position.x - lastXPosition);
        distanceTraveled += deltaX;
        textMetter.text = ""+(int)distanceTraveled;
        // Cập nhật vị trí x của nhân vật trong khung hình trước đó
        lastXPosition = transform.position.x;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            grounded = true;
            jumpCount = 0;
            anim.SetBool("run", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            grounded = false;
            anim.SetBool("run", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "deephold")
        {
            death.Play();
            Metter.text = ""+(int)distanceTraveled;
            Score.text = ""+score;
            panelGameOver.SetActive(true);
            Time.timeScale = 0;
        }

        if (other.gameObject.tag == "bom")
        {
            TakeDamage(20);
            boms.Play();
            // Xóa object bom và hiệu ứng nổ sau một khoảng thời gian ngắn
            Destroy(other.gameObject, 1f);
            if (currentHealth == 0)
            {
                panelGameOver.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
        if (other.gameObject.tag == "coin")
        {
            coin.Play();
            other.gameObject.tag = "Finish";
            score += 1;
            textScore.text = "" + score;
            Destroy(other.gameObject);
            if (score == 5)
            {
                CameraControll.speed += 1;
            }
            
            if (score == 10)
            {
                CameraControll.speed += 1;
            }
            
            if (score == 15)
            {
                CameraControll.speed += 1;
            }
            
            if (score == 30)
            {
                CameraControll.speed += 1;
            }
        }
    }
}
