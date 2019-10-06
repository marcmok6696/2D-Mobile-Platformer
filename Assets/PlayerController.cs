using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int exterJumps;
    public Animator animator;
    public float moveSpeed = 5.0f;
    private float horizontalMove = 0.0f;
    private bool faceRight = true;

    public bool isGrounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float checkRadius;

    public  float jumpForce;
    private Rigidbody2D rb;
    public float fallMultiplier = 2.5f;

    public Joystick joystick;
    public float MaxHp = 100;
    public float CurrentHP;
    public Image HPbar;
    public GameObject DieParticle;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator.SetBool("isGrounded", true);
        CurrentHP = MaxHp;
        HPbar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        checkHPbar();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        animator.SetBool("isGrounded", isGrounded);
        if (isGrounded == true) {
            exterJumps = 1;
        }
        Jump();
        animator.SetFloat("vSpeed", rb.velocity.y);
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (joystick.Horizontal >= 0.2f)
        {
            horizontalMove = 1.0f;
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            horizontalMove = -1.0f;
        }
        else {
            horizontalMove = 0.0f;
        }
        //horizontalMove = joystick.Horizontal;
        horizontalMove = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalMove, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        Flip(horizontalMove);
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

        
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && exterJumps > 0)
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            exterJumps--;

        }
        else if (Input.GetButtonDown("Jump") && isGrounded == true && exterJumps == 0) {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Flip(float horizontal) {
        if (horizontal > 0 && !faceRight || horizontal < 0 && faceRight) {
            faceRight = !faceRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    public void GetDamaged(int damage) {
        CurrentHP = CurrentHP - damage;
        checkHPbar();
        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    private void checkHPbar() {
        HPbar.fillAmount = CurrentHP / MaxHp;
        if (CurrentHP / MaxHp > 0.5)
        {
            HPbar.color = Color.green;
        }
        if (CurrentHP / MaxHp <= 0.5)
        {
            HPbar.color = Color.yellow;
        }
        if (CurrentHP / MaxHp <= 0.2)
        {
            HPbar.color = Color.red;
        }

    }
    public void Die()
    {
        HPbar.fillAmount = 0;
        Instantiate(DieParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
