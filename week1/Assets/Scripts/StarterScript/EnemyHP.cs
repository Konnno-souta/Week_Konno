using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    /// <summary>
    /// 最大HP
    /// </summary>
    [SerializeField] float maxHP = 100f;

    /// <summary>
    /// 現在HP
    /// </summary>
    float currentHP;

    /// <summary>
    /// HPバー（Image）
    /// </summary>
    [SerializeField] Image hpBar;

    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        // 0以下になったら死亡
        if (currentHP <= 0)
        {
            Die();
        }

        UpdateHPBar();
    }

    /// <summary>
    /// HPバー更新
    /// </summary>
    void UpdateHPBar()
    {
        if (hpBar == null) return;

        float ratio = currentHP / maxHP;

        // バーの長さを変更（0から1）
        hpBar.fillAmount = ratio;

        // 色を緑→赤に変化
        hpBar.color = Color.Lerp(Color.red, Color.green, ratio);
    }

    /// <summary>
    /// 死亡処理
    /// </summary>
    void Die()
    {
        Destroy(gameObject);
    }
}