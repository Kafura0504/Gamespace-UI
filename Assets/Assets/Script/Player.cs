using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    [Header("Player Ui Stat")]
    public int health = 3;
    public int score = 0;
    public int gold = 99;
    [Header("for power up")]
    public GameObject shieldPrefab;
    public float magnetDuration = 10f;
    public float magnetRadius = 10f;

    [HideInInspector] public bool shieldActive = false; //to check if the shield is active

    [Header("Ui Reference")]
    public HorizontalLayoutGroup healthBar;
    public GameObject healthBarPrefab;
    public TextMeshProUGUI scoreText;

    public GameObject destructionFX;

    public static Player instance;

    private void Awake()
    {
            instance = this;
    }

    private void Start()
    {
        UpdateHealthBar();
        UpdateScoreUI();
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)
    {
        health -= damage;
        UpdateHealthBar();
        if (health <= 0) //if 'Player's' health is less or equal to 0
            Destruction(); //calling destruction procedure
    }

    //'Player's' destruction procedure
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        gameObject.SetActive(false);
        GameManager.Instance.ChangeState(GameState.Lose);
    }
    public void UpdateHealthBar()
    {
        // Hapus semua child terlebih dahulu
        foreach (Transform child in healthBar.transform)
        {
            Destroy(child.gameObject);
        }

        // Tambahkan health bar sesuai jumlah nyawa
        for (int i = 0; i < health; i++)
        {
            Instantiate(healthBarPrefab, healthBar.transform);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    public void ActivateShield()
    {
        if (shieldPrefab != null && !shieldActive)
        {
            GameObject shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            shield.transform.SetParent(transform); // Set shield as child of Player
            RotatingShield rotatingShield = shield.GetComponent<RotatingShield>();
            if (rotatingShield != null)
            {
                rotatingShield.isPlayerShield = true; // Set to true for player shield
            }
            shieldActive = true;
        }
    }
}