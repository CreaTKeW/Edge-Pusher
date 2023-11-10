using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
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
