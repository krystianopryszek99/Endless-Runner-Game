using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the enemy
public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHeath = 100;
    [SerializeField] int scoreForEnemy = 10; // score when we kill enemy
    int currentHealth;

    // Enemy health is max at the start 
    void Start()
    {
        currentHealth = maxHeath;
    }

    // when enemy takes damage 
    // take his life
    // play the animation 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Take Damage");

        // when enemies health goes to 0, 
        // he will add player score and die
        if(currentHealth <= 0)
        {
            // when you kill enemy, the player will receive score 
            GameData.singleton.UpdateScore(scoreForEnemy);
            // enemy dies
            Die();
        }
    }

    // when enemy dies
    // print message to console
    // play animation 
    void Die()
    {
        Debug.Log("Enemy is dead!");

        animator.SetBool("isDead", true);

        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }
}
