using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("ÉQÅ[ÉÄUI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    [Header("ÉäÉUÉãÉgUI")]
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI finalScoreText;

    [Header("êßå¿éûä‘")]
    public float timeLimit = 60f;

    private float currentTime;
    private int score;
    private bool isGameEnd;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentTime = timeLimit;

        resultPanel.SetActive(false);
    }

    private void Update()
    {
        if (isGameEnd)
            return;

        currentTime -= Time.deltaTime;

        timerText.text = "TIME : " + currentTime.ToString("F0");
        scoreText.text = "SCORE : " + score;

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void GameClear()
    {
        ShowResult("CLEAR");
    }

    public void GameOver()
    {
        ShowResult("GAME OVER");
    }

    private void ShowResult(string result)
    {
        isGameEnd = true;

        Time.timeScale = 0f;

        resultPanel.SetActive(true);

        resultText.text = result;
        finalScoreText.text = "SCORE : " + score;
    }

    public void Retry()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name);
    }

    public void Title()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("TitleJump");
    }
}