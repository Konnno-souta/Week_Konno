using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    // éŒÇﬂå„ÇÎà íuÅiNIKKEÇ¡Ç€Ç¢Åj
    [SerializeField] private Vector3 offset = new Vector3(2.5f, 4f, -5f);

    void LateUpdate()
    {
        Vector3 targetPos = target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            5f * Time.deltaTime
        );

        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}