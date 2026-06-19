using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // 弾
    public Transform firePoint;       // 発射位置
    public float fireRate = 0.2f;     // 発射間隔（秒）

    private bool isFiring = false;    // ←押してるかどうか
    private float nextFireTime = 0f;

    // Spaceキーの入力
    public void OnFire(InputAction.CallbackContext context)
    {
        // 押した瞬間
        if (context.started)
        {
            isFiring = true;
            Debug.Log("発射開始");
        }

        // 離した瞬間
        if (context.canceled)
        {
            isFiring = false;
            Debug.Log("発射停止");
        }
    }

    void Update()
    {
        // 押してる＆発射可能時間なら撃つ
        if (isFiring && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (firePoint == null || bulletPrefab == null)
        {
            Debug.LogError("設定ミス（firePoint/bulletPrefab）");
            return;
        }

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // デバッグ（方向確認）
        Debug.DrawRay(firePoint.position, firePoint.forward * 10f, Color.red, 1f);

        Debug.Log("発射中: " + Time.time);
    }
}