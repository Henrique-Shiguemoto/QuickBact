using UnityEngine;

public class PlanetSize : MonoBehaviour
{
    private Vector3 planetSize;
    private Vector3 originalSize;
    private float x = 0;
    private Vector3 amplitude;
    private Vector3 offset;
    private void Start()
    {
        //Varying size
        planetSize = GetComponent<Transform>().localScale;
        //Original size
        originalSize = planetSize;
        //amplitude of harmonic scaling
        amplitude = 0.2f * originalSize;
        //offset of harmonic scalling
        offset = 0.8f * originalSize;
    }

    void FixedUpdate()
    {
        planetSize = amplitude * Mathf.Sin(x) + offset;
        gameObject.transform.localScale = planetSize;
        x += 0.05f;
    }
}
