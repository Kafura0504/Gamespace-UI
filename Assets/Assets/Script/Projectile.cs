using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the damage and defines whether the projectile belongs to the ‘Enemy’ or to the ‘Player’, whether the projectile is destroyed in the collision, or not and amount of damage.
/// </summary>

public class Projectile : MonoBehaviour {

    [Tooltip("Damage which a projectile deals to another object. Integer")]
    public int damage;

    [Tooltip("Whether the projectile belongs to the ‘Enemy’ or to the ‘Player’")]
    public bool enemyBullet;

    [Tooltip("Whether the projectile is destroyed in the collision, or not")]
    public bool destroyedByCollision;
    public float destroyOvertime = 2f;

    private void Start()
    {
        Destroy(gameObject, destroyOvertime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hitSomething = false;

        // Projectile mengenai Player
        if (enemyBullet && collision.CompareTag("Player"))
        {
            Player.instance.GetDamage(damage);
            hitSomething = true;
        }
        // Projectile mengenai Enemy
        else if (!enemyBullet && collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetDamage(damage);
                hitSomething = true;
            }
        }
        // Projectile mengenai Shield
        else if (collision.CompareTag("Shield"))
        {
            RotatingShield shield = collision.GetComponent<RotatingShield>();
            if (shield != null && shield.isPlayerShield == enemyBullet)
            {
                shield.TakeDamage(damage);
                hitSomething = true;
            }
        }

        if (hitSomething && destroyedByCollision)
            Destruction();
    }


    void Destruction() 
    {
        Destroy(gameObject);
    }
}


