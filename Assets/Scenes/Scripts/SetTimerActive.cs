using UnityEngine;

public class SetTimerActive : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    private float playerYPositionToTriggerTimer = 192f;
    void Update()
    {
        if (playerPosition.position.y > playerYPositionToTriggerTimer)
        {
            GetComponent<StateManager>().timerIsActive = true;
        }
    }
}
