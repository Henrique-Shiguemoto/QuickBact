using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollisionEnemy : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject[] enemyList;
    [SerializeField] private Text textObject;
    [SerializeField] private float reloadSceneDelay;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        foreach (GameObject enemy in enemyList)
        {
            if (enemy != null)
            {
                if (Vector2.Distance(enemy.transform.position, gameObject.transform.position) <= enemy.transform.localScale.x/2 + gameObject.transform.localScale.x/2)
                {
                    GameObject.Find("GameManager").GetComponent<StateManager>().PlaySound("playerDeath");
                    gameObject.SetActive(false);
                    textObject.text = "GAME OVER";
                    gameManager.GetComponent<StateManager>().Invoke("EndGame", reloadSceneDelay);
                }
            }
            
        }
    }
}
