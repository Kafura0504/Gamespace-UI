using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [Header("Level Setup")]
    public WaveData[] allLevelData; 
    public int currentLevel = 0;
    public float timeBetweenWaves = 7f;
    public static LevelController Instance { get; private set; }

    [Header("References")]
    public Transform enemyWavesSpawn;

    void Awake()
    {
        Instance = this;
    }

    public void StartLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= allLevelData.Length)
        {
            Debug.LogError("Invalid level index: " + levelIndex);
            return;
        }

        WaveData waveData = allLevelData[levelIndex];

        foreach (var wave in waveData.enemyWaves)
        {
            StartCoroutine(CreateEnemyWave(wave.timeToStart, wave));
            if (wave.waveType == WaveType.FinishWave)
            {
                StartCoroutine(LoadNextLevel(wave.timeToStart + timeBetweenWaves));
            }
        }

    }

    IEnumerator CreateEnemyWave(float delay, EnemyWaves waveData)
    {
        if (delay > 0)
            yield return new WaitForSeconds(delay);

        if (Player.instance != null)
        {
            Instantiate(waveData.wavePrefab, enemyWavesSpawn.position, Quaternion.identity);
        }
    }

    public IEnumerator LoadNextLevel(float time)
    {
        yield return new WaitForSeconds(time);
        currentLevel++;
        if (currentLevel < allLevelData.Length)
        {
            StopAllCoroutines();
            StartLevel(currentLevel);
        }
        else
        {
            Debug.Log("All levels complete!");
            GameManager.Instance.ChangeState(GameState.Win);
            // Mungkin masuk ke scene Victory, main menu, dll.
        }
    }
}
