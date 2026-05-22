using UnityEngine;
using TMPro; // TextMeshProを使うために必要

public class ScoreUI : MonoBehaviour
{
    /// <summary>
    /// スコア表示用のテキスト
    /// </summary>
    [SerializeField] private TMP_Text scoreText;

    /// <summary>
    /// 現在のスコア
    /// </summary>
    private int score = 0;

    /// <summary>
    /// ゲーム開始時に呼ばれる
    /// </summary>
    void Start()
    {
        UpdateScore(); // 初期表示
    }

    /// <summary>
    /// スコアを加算する
    /// </summary>
    /// <param name="value">加算するスコア</param>
    public void AddScore(int value)
    {
        score += value;     // スコアを増やす
        UpdateScore();      // UI更新
    }

    /// <summary>
    /// スコア表示を更新する
    /// </summary>
    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score;
        }
    }
}