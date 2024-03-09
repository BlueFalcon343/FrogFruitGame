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

        //Movement
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }

    private void FixedUpdate()
    {
        //Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if(isGrounded)
        {
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void getFruit(int amount)
    {
        //Increases players jump height upon getting a fruit
        jumpForce = jumpForce + 50.0f;
        score = score + amount;
        setScoreText();
    }

    void setScoreText()
    {
        //Displays number of fruit
        scoreText.text = "Fruit: " + score.ToString();
    }

    public void Death()
    {
        //Simple respawn on death that grabs current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
