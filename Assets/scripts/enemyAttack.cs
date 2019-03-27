using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
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
    public LayerMask whatIsPlayer;

    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Physics2D.OverlapBox(attackPos.position, new Vector2(attackRangeX, attackRangeY),0, whatIsPlayer))
            {
                Collider2D [] playerToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsPlayer);
                for (int i = 0; i < playerToDamage.Length; i++)
                {
                    playerToDamage[i].GetComponent<playerController>().takeDamage(Random.Range(damage - damageVariety, damage + damageVariety));
                }


                anim.SetTrigger("attack");
                timeBtwAttack = timeBtwAttackValue;
            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector2(attackRangeX, attackRangeY));
    }
}
