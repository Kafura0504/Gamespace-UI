using UnityEngine;

[System.Serializable]
public enum BonusType
{
    WeaponGun, //increasing weapon power
    Health,      //increasing health
    Shield,
    DamageBoost,
    SpeedBoost,
    RateOfFireBoost,
    GoldMagnet,
}
public class Bonus : MonoBehaviour
{

    public BonusType bonusType;
    //when colliding with another object, if another objct is 'Player', sending command to the 'Player'
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (bonusType)
            {
                case BonusType.WeaponGun:
                    if (PlayerShooting.instance.weaponPower < PlayerShooting.instance.maxweaponPower)
                    {
                        PlayerShooting.instance.weaponPower++;
                    }
                    break;
                case BonusType.Health:
                    Player.instance.health++;
                    Player.instance.UpdateHealthBar();
                    break;
                case BonusType.Shield:
                    if (Player.instance.shieldPrefab != null)
                    {
                        Instantiate(Player.instance.shieldPrefab, collision.transform.position, Quaternion.identity, collision.transform);
                    }
                    break;
                case BonusType.DamageBoost:
                    if (PlayerShooting.instance.damage < 5)
                    {
                        PlayerShooting.instance.damage++;
                    }
                    break;
                case BonusType.RateOfFireBoost:
                    if (PlayerShooting.instance.fireRate < 7f)
                    {
                        PlayerShooting.instance.fireRate += 0.5f; //increase fire rate                    
                    }
                    break;
            }
            Destroy(gameObject);
        }
    }
}