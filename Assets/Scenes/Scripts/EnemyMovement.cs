using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float distanceThreshold;
    [SerializeField] private GameObject targetFollow;

    private void Start()
    {
        
    }

    void Update()
    {
        if (CalculateDistance(gameObject, targetFollow) <= distanceThreshold)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetFollow.transform.position, enemySpeed*Time.deltaTime);
        }
    }

    float CalculateDistance(GameObject obj1, GameObject obj2)
    {
        Vector2 v1 = obj1.transform.position;
        Vector2 v2 = obj2.transform.position;
        float result = Vector2.Distance(v1, v2);
        return result;
    }
}
