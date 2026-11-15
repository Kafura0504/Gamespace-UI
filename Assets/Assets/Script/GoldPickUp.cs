using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Transform targetPlayer;
    private bool attracted = false;
    public int goldValue = 5; 

    void Update()
    {
        if (attracted && targetPlayer != null)
        {
            Vector3 direction = (targetPlayer.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    public void AttractToPlayer(Transform player)
    {
        targetPlayer = player;
        attracted = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<Player>().AddGold(goldValue);
        }
    }
}
