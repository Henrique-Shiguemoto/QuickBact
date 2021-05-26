using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWall : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 0.5f, Space.Self);
    }
}
