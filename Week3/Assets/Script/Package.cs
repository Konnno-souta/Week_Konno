using UnityEngine;

public class Package : MonoBehaviour
{
    [Header("色Index")]
    public int packageIndex;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーが触れた
        if (other.CompareTag("Player"))
        {
            // 荷物取得
            gameManager.PickPackage(packageIndex);

            // 荷物消す
            gameObject.SetActive(false);
        }
    }
}