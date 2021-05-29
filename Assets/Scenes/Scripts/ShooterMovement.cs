using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMovement : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float distanceThreshold;
    [SerializeField] private float shooterSpeed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float timeBetweenShots;
    private GameObject target;
    private float timePass = 1f;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector2.Distance(targetTransform.position, transform.position) <= distanceThreshold)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, shooterSpeed * Time.deltaTime);

            if (timePass <= 0f && target.activeSelf)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                timePass = timeBetweenShots;
            }
            else
            {
                timePass -= Time.deltaTime;
            }
        }
    }
}
