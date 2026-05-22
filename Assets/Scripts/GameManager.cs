using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("スコア表示")]
    [SerializeField] private TMP_Text scoreText;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// スコア追加
    /// </summary>
    public void AddScore(int value)
    {
        score += value;

        scoreText.text = "Score : " + score;
    }
}