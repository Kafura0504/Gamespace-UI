using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Objects/WaveData")]
public class WaveData : ScriptableObject
{
    public LevelType levelType;
    public EnemyWaves[] enemyWaves;
}

[System.Serializable]
public class EnemyWaves
{
    [Tooltip("Waktu wave dimulai sejak awal level")]
    public float timeToStart;

    public WaveType waveType;

    [Tooltip("Prefab dari wave enemy")]
    public GameObject wavePrefab;
}

[System.Serializable]
public enum WaveType
{
    NormalWave,
    Trigger,
    Portal,
    BossWave,
    FinishWave
}

[System.Serializable]
public enum LevelType
{
    Normal,
    Portal,
    Boss,
    Shop
}