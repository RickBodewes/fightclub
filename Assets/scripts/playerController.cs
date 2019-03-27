using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    

    [Header("player stats")]
    public int healthValue;
    private int health;
    public int speed;
    public int jumpPower;
    public int extraJumps;
    private int dubJump;

    

    [Header("others")]


    public LayerMask ground;
    public Transform groundCheck;
    public float checkRadius;
    public Slider healthBar;



    private Animator anim;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;


    [Header("health regen")]
    public int regenValue;
    public float regenTimeIntervalValue;
    private float regenTimeInterval;



    // Start is called before the first frame update
    void Start()
    {
        dubJump = extraJumps;

        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        health = healthValue;

        regenTimeInterval = regenTimeIntervalValue;
    }


    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
    }

    // Update is called once per frame
    void Update()
    {

        //voor het draaien en loop animatie
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("isRunning", true);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetBool("isRunning", true);
        }
        else if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }

        //reset de doublejump waarde en zet animatie voor springen
        if (isGrounded == true)
        {
            dubJump = extraJumps;
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        //springen
        if (Input.GetKeyDown(KeyCode.Space) && dubJump > 0)
        {
            anim.SetTrigger("takeOf");
            rb.velocity = Vector2.up * jumpPower;
            dubJump--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && dubJump == 0 && isGrounded == true)
        {
            anim.SetTrigger("takeOf");
            rb.velocity = Vector2.up * jumpPower;
        }


        
        
        //regenerate stuff
        if (regenTimeInterval <= 0)
        {
            if (health + regenValue < 100)
            {
                health += regenValue;
            }
            else
            {
                health = healthValue;
            }


            regenTimeInterval = regenTimeIntervalValue;
        }
        else
        {
            regenTimeInterval -= Time.deltaTime;
        }


        //displays health on healthbar
        healthBar.value = health;

        if (health <= 0)
        {
            SceneManager.LoadScene("endScreen");
        }

        


    }









    public void takeDamage(int damage)
    {
        health -= damage;
    }




}
