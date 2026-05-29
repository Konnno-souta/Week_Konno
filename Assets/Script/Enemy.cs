using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 100f;

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}