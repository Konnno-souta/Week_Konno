using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [Header("床Prefab")]
    [SerializeField]
    private GameObject floorPrefab;

    [Header("プレイヤー")]
    [SerializeField]
    private Transform player;

    [Header("床間隔")]
    [SerializeField]
    private float spacing = 4f;

    [Header("生成する最大Z座標")]
    [SerializeField]
    private float maxZ = 100f;

    /// <summary>
    /// 最後の生成位置
    /// </summary>
    private Vector3 spawnPos;

    private void Start()
    {
        // 開始位置
        spawnPos = player.position;

        // 最初の位置を少し前へ
        spawnPos += player.forward * spacing;

        GenerateFloors();
    }

    /// <summary>
    /// 床生成
    /// </summary>
    private void GenerateFloors()
    {
        while (spawnPos.z < maxZ)
        {
            SpawnFloor();
        }
    }

    /// <summary>
    /// 1枚生成
    /// </summary>
    private void SpawnFloor()
    {
        // 左右ランダム
        int randomX = Random.Range(-1, 2);

        // X移動
        spawnPos.x += randomX * spacing;

        // Z前進
        spawnPos.z += spacing;

        // Y固定
        spawnPos.y = 0;

        // 床生成
        Instantiate(
            floorPrefab,
            spawnPos,
            Quaternion.identity
        );
    }
}