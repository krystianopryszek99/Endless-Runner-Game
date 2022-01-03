using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for player attack
public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 1.0f;
    public LayerMask enemyLayers;
    public int attackDamage = 100;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Player attack set on right mouse click
    // allows only one attack per click
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRange;
            }
        }
    }

    // When player attacks 
    // play animation
    // when kills enemy, updates enemies health
    void Attack()
    {
        animator.SetTrigger("Attack 01");
        // detect enemies
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
} 
