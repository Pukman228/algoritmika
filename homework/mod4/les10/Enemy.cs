using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed = 1f;
    float borderPosX;
    public Animator animator;
    public float startTimer = 1f;
    public float currentTimer = 0f;
    public float speedPerLevel = 0.2f;

    public void TakeDamage()
    {
        health -= 1;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speed += speedPerLevel * LevelController.level;
        borderPosX = Corn.singleton.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }

        float enemyPosX = transform.position.x;

        if (enemyPosX > borderPosX)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
            animator.SetBool("isMoving", true);
        } else
        {
            animator.SetBool("isMoving", false);
            if (currentTimer <= 0)
            {
                Attack();
                currentTimer = startTimer;
            }

        }

    }

    public void Attack()
    {
        Corn.singleton.TakeDamage();
    }
}
