using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    private Animator anim;


    [Header("attack stats")]
    public int damage;
    public int damageVariety;
    private float timeBtwAttack;
    public float timeBtwAttackValue;

    [Header("others")]
    public Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask whatIsEnemy;


    



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(timeBtwAttack <= 0)
        {
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehaviour>().takeDamage(Random.Range(damage - damageVariety, damage + damageVariety));
                }

                
                anim.SetTrigger("attack");
                timeBtwAttack = timeBtwAttackValue;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

        /*if (Physics2D.OverlapBox(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0))
        {
            Debug.Log("hello ");
        }*/

    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector2(attackRangeX, attackRangeY));
    }

}
