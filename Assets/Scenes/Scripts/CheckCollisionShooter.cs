using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollisionShooter : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private GameObject[] shooterList;
    [SerializeField] private Text gameOverText;
    [SerializeField] private float reloadSceneDelay;

    private void Start()
    {
        shooterList = GameObject.FindGameObjectsWithTag("Shooter");
    }

    private void Update()
    {
        foreach (GameObject shooter in shooterList)
        {   
            if (Vector2.Distance(shooter.transform.position, transform.position) <= (shooter.transform.localScale.x/2 + transform.localScale.x/2))
            {
                gameObject.SetActive(false);
                gameOverText.text = "GAME OVER";
                gameManager.GetComponent<StateManager>().Invoke("EndGame", reloadSceneDelay);
            }
        }
    }
}
