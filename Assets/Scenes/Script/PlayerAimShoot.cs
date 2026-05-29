using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimShoot : MonoBehaviour
{
    [Header("カメラ")]
    [SerializeField] private Camera mainCamera;

    [Header("弾")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [Header("射撃設定")]
    [SerializeField] private float bulletSpeed = 50f;
    [SerializeField] private float fireRate = 0.1f;

    [SerializeField] private bool useTargeting = true;

    private float nextFireTime;
    private Vector3 mousePosition;
    private Transform currentTarget;

    void Update()
    {
        Aim();
        SelectTarget();
        Shoot();
    }

    private void Aim()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Ray ray = mainCamera.ScreenPointToRay(mouseScreen);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            mousePosition = hit.point;
        }
    }

    private void SelectTarget()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseScreen = Mouse.current.position.ReadValue();
            Ray ray = mainCamera.ScreenPointToRay(mouseScreen);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    currentTarget = hit.collider.transform;
                }
                else
                {
                    currentTarget = null;
                }
            }
        }
    }

    private void Shoot()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            if (Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + fireRate;

                GameObject bullet = Instantiate(
                    bulletPrefab,
                    firePoint.position,
                    Quaternion.identity
                );

                Vector3 shootDirection;

                if (useTargeting && currentTarget != null)
                {
                    shootDirection =
                        (currentTarget.position - firePoint.position).normalized;
                }
                else
                {
                    shootDirection =
                        (mousePosition - firePoint.position).normalized;
                }

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.linearVelocity = shootDirection * bulletSpeed;
            }
        }
    }
}