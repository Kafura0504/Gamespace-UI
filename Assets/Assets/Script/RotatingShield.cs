using UnityEngine;

public class RotatingShield : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public int shieldHealth = 3;
    public bool isPlayerShield = true; 

    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        shieldHealth -= damage;
        if (shieldHealth <= 0)
        {
            DestroyShield();
        }
    }

    void DestroyShield()
    {
        if (isPlayerShield)
        {
            Player.instance.shieldActive = false; // Update the player's shield status
        }
        Destroy(gameObject);
    }
}