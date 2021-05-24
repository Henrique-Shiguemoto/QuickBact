using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform bacteria;
    public Vector3 offset;

    private void FixedUpdate()
    {
        transform.position = bacteria.position + offset;
    }
}
