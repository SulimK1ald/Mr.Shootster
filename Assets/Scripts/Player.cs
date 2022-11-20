using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private float moveInput;
    public float speed = 5;
    public float jumpForce;
    public bool isGrounded;
    public Transform feetPos;
    public int coins;
    public Text coinsText;

    //private bool facingRight = true;
    //private Animator anim;



    void Start()
    {
        // anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        moveInput = Input.GetAxis("Horizontal");

/*        if (!facingRight && moveInput > 0)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        else if (facingRight && moveInput < 0)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }*/
    }

    private void Update()
    {
        CheckGround();
        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = Vector2.up * jumpForce;
            //anim.SetTrigger("takeOff");
        }
    }
    void CheckGround()
    {
        Collider2D[] playerOnTheGround = Physics2D.OverlapCircleAll(feetPos.position, 0.3f);
        isGrounded = playerOnTheGround.Length > 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = coins.ToString();
        }
    }

}
