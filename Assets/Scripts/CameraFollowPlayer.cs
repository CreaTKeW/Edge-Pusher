using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        transform.position = target.position + offset;
    }
}
