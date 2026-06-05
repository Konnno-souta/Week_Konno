using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("荷物")]
    public GameObject[] packages;

    [Header("配送先")]
    public GameObject[] deliveryPoints;

    [Header("現在持っている荷物")]
    public int currentPackageIndex = -1;

    [Header("スコア")]
    public int score = 0;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text packageText;

    [Header("色ごとの得点")]
    public int[] scoreValues =
{
    10, // 赤
    20, // 青
    30, // 緑
    40, // 黄
    50  // 紫
};
    public string[] colorNames =
{
    "赤",
    "青",
    "緑",
    "黄",
    "紫"
};
    public string[] colorTexts =
{
    "<color=red>赤</color>",
    "<color=blue>青</color>",
    "<color=green>緑</color>",
    "<color=yellow>黄</color>",
    "<color=purple>紫</color>"
};
    private int currentSpawnIndex;

    private void Start()
    {
        SpawnNewPackage();
        UpdateUI();
    }

    // 荷物を拾った
    public void PickPackage(int index)
    {
        currentPackageIndex = index;

        UpdateUI();
    }
    public void CheckDelivery(int deliveryIndex)
    {
        if (currentPackageIndex == -1)
            return;

        if (currentPackageIndex == deliveryIndex)
        {
            // 色ごとの得点
            score += scoreValues[currentPackageIndex];

            Debug.Log(
                "配送成功！ +" +
                scoreValues[currentPackageIndex]
            );

            currentPackageIndex = -1;

            SpawnNewDelivery();
        }
        else
        {
            Debug.Log("違う配送先");

            currentPackageIndex = -1;
        }

        UpdateUI();
    }

    // 新しい荷物を出す
    void SpawnNewPackage()
    {
        // 全て非表示
        for (int i = 0; i < packages.Length; i++)
        {
            packages[i].SetActive(false);
        }

        // ランダム
        int rand = Random.Range(0, packages.Length);

        packages[rand].SetActive(true);
    }

    // UI更新
    void UpdateUI()
    {
        scoreText.text = "Score : " + score;

        if (currentPackageIndex == -1)
        {
            packageText.text = "荷物なし";
        }
        else
        {
            packageText.text =
                "持っている荷物 : " +
                colorTexts[currentPackageIndex];
        }
    }
    void SpawnNewDelivery()
    {
        // 荷物全部消す
        foreach (GameObject package in packages)
        {
            package.SetActive(false);
        }

        // 配送先全部消す
        foreach (GameObject point in deliveryPoints)
        {
            point.SetActive(false);
        }

        // ランダム選択
        int rand = Random.Range(0, packages.Length);

        // 同じ色だけ表示
        packages[rand].SetActive(true);
        deliveryPoints[rand].SetActive(true);
    }
}