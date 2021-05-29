using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform target;
    private Vector2 targetInitialPosition;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetInitialPosition = new Vector2(target.position.x, target.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetInitialPosition, speed * Time.deltaTime);

        if (transform.position.Equals(targetInitialPosition))
        {
            Destroy(gameObject);
        }
    }
}
