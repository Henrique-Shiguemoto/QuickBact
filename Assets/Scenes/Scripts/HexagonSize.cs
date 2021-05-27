using UnityEngine;

public class HexagonSize : MonoBehaviour
{
    private Vector3 hexagonSize;
    private Vector3 originalSize;
    private float x = 0;
    private Vector3 amplitude;
    private Vector3 offset;
    private void Start()
    {
        //Varying size
        hexagonSize = GetComponent<Transform>().localScale;
        //Original size
        originalSize = hexagonSize;
        //amplitude of harmonic scaling
        amplitude = 0.2f * originalSize;
        //offset of harmonic scalling
        offset = 0.8f * originalSize;
    }

    void FixedUpdate()
    {
        hexagonSize = amplitude * Mathf.Sin(x) + offset;
        gameObject.transform.localScale = hexagonSize;
        x += 0.05f;
    }
}
