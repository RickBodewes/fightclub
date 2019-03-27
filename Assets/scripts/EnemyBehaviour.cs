using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    


    [Header("stats")]
    
    public float healthValue;
    private float health;
    public int speedValue;
    private int speed;
    public float dazedTimeValue;
    private float dazedTime;
    public int knockback;
    public int knockbackHeight;

    [Header("others")]
    public float DistanceToStop;
    public Transform healthBar;
    public int scoreAmount;


    
    private Animator anim;
    private Transform target;
    private float distanceToPlayer;
    private Rigidbody2D rb;

    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        speed = speedValue;

        health = healthValue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moves the enemy towards the player

        distanceToPlayer = target.position.x - transform.position.x;


        if (distanceToPlayer < -DistanceToStop || distanceToPlayer > DistanceToStop)
        {
            if (distanceToPlayer < -DistanceToStop)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }else if (distanceToPlayer > DistanceToStop)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }


        }
    }



    void Update()
    {

        //flips teh player arround
        if (distanceToPlayer > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            healthBar.localPosition = new Vector2(-1.5f, 4);
            healthBar.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (distanceToPlayer < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            healthBar.eulerAngles = new Vector3(0, 0, 0);
            healthBar.localPosition = new Vector2(1.5f, 4);
        }

        //sets animation
        if(rb.velocity.x > 0 || rb.velocity.x < 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //removes daze
        if (dazedTime <= 0)
        {
            speed = speedValue;
        }
        else
        {
            dazedTime -= Time.deltaTime;
        }

        //kills if health is 0 below 
        if (health <= 0)
        {
            GameObject.Find("enemies").GetComponent<spawner>().removeEnemy();
            GameObject.Find("scoreManager").GetComponent<scoreManager>().scoreAdder(scoreAmount);
            Destroy(gameObject);
        }



    }


    //when damage is taken this will execute
    public void takeDamage(int damage)
    {
        dazedTime = dazedTimeValue;
        speed = 0;

        if (distanceToPlayer > 0)
        {
            rb.velocity = new Vector2(-knockback, knockbackHeight);
        }
        else if (distanceToPlayer < 0)
        {
            rb.velocity = new Vector2(knockback, knockbackHeight);
        }
        health -= damage;
        healthBar.localScale = new Vector3(health / healthValue * 0.5f, 0.5f, 1);
    }
   
}
