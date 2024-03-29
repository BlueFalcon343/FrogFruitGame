using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Public variables
    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI startText;
    public AudioSource FruitSound;

    //Private variables
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        score = 0;
        setScoreText();
        Destroy(startText, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //Get Inputs
        moveDirection = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        //Animation and directional flipping
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FixedUpdate()
    {
        //Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);

        //Movement
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void setScoreText()
    {
        //Displays number of fruit
        scoreText.text = "Fruit: " + score.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            jumpForce = jumpForce + 50.0f;
            score++;
            setScoreText();
            FruitSound.Play();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.layer == 8)
        {
            //Simple respawn on death that grabs current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
