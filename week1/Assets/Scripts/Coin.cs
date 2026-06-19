using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score = 100;

    void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);

            Destroy(gameObject);
        }
    }
}