using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("弾Prefab")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("弾の発射位置")]
    [SerializeField] private Transform firePoint;

    [Header("弾速")]
    [SerializeField] private float bulletSpeed = 40f;

    [Header("連射速度")]
    [SerializeField] private float fireRate = 0.1f;

    private float nextFireTime;

    void Update()
    {
        Aim();

        // 左クリック射撃
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    /// <summary>
    /// マウス方向へ向く
    /// </summary>
    private void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);

            Vector3 lookDir = targetPoint - transform.position;

            lookDir.y = 0f;

            transform.forward = lookDir;
        }
    }

    /// <summary>
    /// 弾発射
    /// </summary>
    private void Shoot()
    {
        if (Time.time < nextFireTime)
            return;

        nextFireTime = Time.time + fireRate;

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.linearVelocity = firePoint.forward * bulletSpeed;
    }
}