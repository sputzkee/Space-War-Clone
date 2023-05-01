using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Transform Player;

    Player plyr;

    public GameObject ExplosionEffect;

    public GameObject EnemyBullet;

    public Image EnemyHealthBar;

    public Administrator manage;

    float health = 100.0f;

    float nowHealth = 100.0f;

    float moveSpeed = 1.0f;

    float bulletSpeed = 500.0f;

    float firingRange = 0.2f;

    float firingTİme = 0.0f;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);

            decreaseHealth(5.0f);
        }
    }

    void decreaseHealth(float value)
    {
        nowHealth -= value;

        plyr.PlayerHealthBar.fillAmount = nowHealth / health;

        if(nowHealth <= 0)
        {
            beLost();
        }
    }
    void beLost()
    {
        Destroy(gameObject);

        GameObject newExplosion = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);

        Destroy(newExplosion, 1.0f);

        manage.showPanel();
    }
    void firing()
    {
        GameObject newBullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * bulletSpeed); //aşağı yönlü olduğundan Vector2.down dedik, player için yaptığımızın aksine.

        Destroy(newBullet, 2.0f);
    }

    void Update()
    {
        if (Player)
        { 

        if(transform.position.x < Player.position.x)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if(transform.position.x > Player.position.x)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if(Player.position.x - transform.position.x <= 0.2f)
        {
            if(Time.time >= firingTİme)
            {
                firing();
                firingTİme = Time.time + firingRange;
            }
        }

        }
    }
}
