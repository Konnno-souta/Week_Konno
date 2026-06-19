using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public float deadLine = -5f;

    void Update()
    {
        if (transform.position.y <= deadLine)
        {
            GameManager.Instance.GameOver();
        }
    }
}