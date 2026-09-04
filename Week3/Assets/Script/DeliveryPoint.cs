using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    [Header("配送先Index")]
    public int deliveryIndex;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤー接触
        if (other.CompareTag("Player"))
        {
            gameManager.CheckDelivery(deliveryIndex);
        }
    }
}