using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /// <summary>
    /// 現在のスコア
    /// </summary>
    public int score = 0;

    /// <summary>
    /// スコア表示用UI
    /// </summary>
    [SerializeField] Text scoreText;

    /// <summary>
    /// スコアを加算する
    /// </summary>
    /// <param name="value">加算する値</param>
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    /// <summary>
    /// UIのスコア表示を更新
    /// </summary>
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score;
        }
    }
}