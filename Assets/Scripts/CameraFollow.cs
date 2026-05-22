using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    /// <summary>
    /// ƒvƒŒƒCƒ„[‚Æ‚Ì‹——£
    /// </summary>
    [SerializeField]
    private Vector3 offset = new Vector3(0, 8, -8);

    void LateUpdate()
    {
        transform.position = target.position + offset;

        transform.LookAt(target);
    }
}