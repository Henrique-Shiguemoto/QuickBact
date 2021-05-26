using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform targetTransform;
    [SerializeField] private float enemySpeed;

    private void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, enemySpeed*Time.deltaTime);
    }
}
