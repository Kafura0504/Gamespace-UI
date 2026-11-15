using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public event Action<GameState> OnGameStateChanged;

    public static GameManager Instance { get; private set; }
    [SerializeField] private int highScore;
    private GameState _currentState;
    public GameState CurrentState => _currentState;

    public GameObject WinPanel;
    public TMP_Text highScoreText;
    public TMP_Text winCurrScoreText;

    public GameObject LosePanel;
    public TMP_Text loseCurrScoreText;
    public GameObject MainMenuPanel;
    public GameObject GamePanel;
    public GameObject PausePanel;

    private void Awake()
    {
        Instance = this;
    }

    public void resetScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void resumeGame()
    {
        ChangeState(GameState.Playing);
    }
    public void pauseGame()
    {
        ChangeState(GameState.Paused);
    }

    public void LoadScene(int sceneIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        highScore = LoadHighScore();

        MainMenuPanel.SetActive(false);
        ChangeState(GameState.Playing);
        LevelController.Instance.StartLevel(LevelController.Instance.currentLevel);
    }

    public void ChangeState(GameState newState)
    {
        if (_currentState == newState)
            return;

        _currentState = newState;
        OnGameStateChanged?.Invoke(_currentState);

        switch (_currentState)
        {
            case GameState.Playing:
                Time.timeScale = 1f;
                GamePanel.SetActive(true);
                PausePanel.SetActive(false);
                break;
            case GameState.Paused:
                Time.timeScale = 0f;
                PausePanel.SetActive(true);
                GamePanel.SetActive(false);
                break;
            case GameState.Lose:
                Debug.Log("Game Over! You Lose.");
                Time.timeScale = 0f;
                LosePanel.SetActive(true);
                GamePanel.SetActive(false);
                loseCurrScoreText.text = "Score: " + Player.instance.score.ToString();
                break;
            case GameState.Win:
                Debug.Log("Congratulations! You Win!");
                WinPanel.SetActive(true);
                GamePanel.SetActive(false);
                winCurrScoreText.text = "Score: " + Player.instance.score.ToString();
                SaveHighScore(Player.instance.score);

                highScoreText.text = "High Score: " + highScore.ToString();
                break;
            case GameState.MainMenu:
                MainMenuPanel.SetActive(true);
                break;
        }
    }

    public void SaveHighScore(int currentScore)
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
    public int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
}
[System.Serializable]
public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    Lose,
    Win
}