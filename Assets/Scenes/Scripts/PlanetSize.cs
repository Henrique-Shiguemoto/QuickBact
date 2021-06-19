using UnityEngine;

public class PlanetSize : MonoBehaviour
{
    private Vector3 planetSize;
    private Vector3 originalSize;
    private float x = 0;
    [SerializeField] private float amplitude_multiplier;
    private Vector3 amplitude;
    [SerializeField] private float offset_multiplier;
    private Vector3 offset;
    [SerializeField] private float growthShrinkSpeed;
    private void Start()
    {
        //Varying size
        planetSize = GetComponent<Transform>().localScale;
        //Original size
        originalSize = planetSize;
        //amplitude of harmonic scaling
        amplitude = amplitude_multiplier * originalSize;
        //offset of harmonic scalling
        offset = offset_multiplier * originalSize;
    }

    void FixedUpdate()
    {
        planetSize = amplitude * Mathf.Sin(x) + offset;
        gameObject.transform.localScale = planetSize;
        x += growthShrinkSpeed;
        if (x >= 2*Mathf.PI)
        {
            x = 0F;
        }
    }
}
