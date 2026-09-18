using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;

    private int enemiesDestroyed = 0;

    public bool gameOver = false;

    public int victoryEnemies = 20;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        if (gameOver)
            return;

        score += points;

        enemiesDestroyed++;

        UpdateScoreText();

        CheckSlowMotion();
        CheckVictory();
    }

    void CheckSlowMotion()
    {
        if (enemiesDestroyed % 5 == 0)
        {
            TimeManager.Instance.ActivateSlowMotion();
        }
    }

    void CheckVictory()
    {
        if (enemiesDestroyed >= victoryEnemies)
        {
            Victory();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        if (gameOver)
            return;

        gameOver = true;

        Debug.Log("GAME OVER!");

        SceneManager.LoadScene("DefeatScene");
    }

    void Victory()
    {
        if (gameOver)
            return;

        gameOver = true;

        Debug.Log("VICTORY!");

        SceneManager.LoadScene("VictoryScene");
    }
}