using UnityEngine;

public class RotateGrid : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    void Update()
    {
        transform.eulerAngles += Vector3.forward * rotationSpeed;
    }
}
