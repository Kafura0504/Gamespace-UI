using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines 'Enemy's' health and behavior. 
/// </summary>
public class Enemy : MonoBehaviour {

    #region FIELDS
    [Tooltip("Health points in integer")]
    public int health;
    public int score = 10; 

    [Tooltip("Enemy's projectile prefab")]
    public GameObject Projectile;
    public GameObject powerUp;
    public GameObject heal;

    //[Tooltip("VFX prefab generating after destruction")]
    public GameObject destructionVFX;
    //public GameObject hitEffect;
    public bool canShoot = true; //whether the 'Enemy' can shoot or not
    [HideInInspector] public int shotChance, powerUpDropChance,healDropChance; //probability of 'Enemy's' shooting during tha path
    [HideInInspector] public float shotTimeMin, shotTimeMax; //max and min time for shooting from the beginning of the path
    #endregion

    private void Start()
    {
        Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));
    }

    //coroutine making a shot
    void ActivateShooting() 
    {
        if (!canShoot) return;

        if (Random.value < (float)shotChance / 100)                             //if random value less than shot probability, making a shot
        {                         
            Instantiate(Projectile,  gameObject.transform.position, this.transform.rotation);             
        }
    }

    //method of getting damage for the 'Enemy'
    public void GetDamage(int damage) 
    {
        health -= damage;           //reducing health for damage value, if health is less than 0, starting destruction procedure
        if (health <= 0)
            Destruction();
        //else
        //    Instantiate(hitEffect,transform.position,Quaternion.identity,transform);
    }    

    //if 'Enemy' collides 'Player', 'Player' gets the damage equal to projectile's damage value
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Projectile!= null)
                Player.instance.GetDamage(Projectile.GetComponent<Projectile>().damage);
            else
                Player.instance.GetDamage(1);

            Destruction();
        }
    }

    //method of destroying the 'Enemy'
    void Destruction()                           
    {        
                if (Random.value < (float)powerUpDropChance / 100)
                {
                    Instantiate(powerUp, transform.position, Quaternion.identity);
                }
                if (Random.value < (float)healDropChance / 100)
                {
                    Instantiate(heal, transform.position, Quaternion.identity);
                }
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Player.instance.AddScore(score);
        Destroy(gameObject);
    }
}
