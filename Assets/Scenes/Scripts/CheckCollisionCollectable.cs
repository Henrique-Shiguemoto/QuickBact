using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollisionCollectable : MonoBehaviour
{
    [SerializeField] private int foodCount = 0;
    [SerializeField] private Text foodCountText;
    [SerializeField] private Text WinText;
    [SerializeField] private float orangeSpeedBoost = 2.5f;
    [SerializeField] private float orangeSpeedBoostTimer = 2f;
    [SerializeField] private int MaxFood;
    [SerializeField] private float reloadSceneDelay;
    private GameObject gameManager;
    private bool isBoosting = false;
    private float playerSpeed;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        playerSpeed = GetComponent<Bacteria2DController>().bactSpeed;
    }

    private void Update()
    {
        if (isBoosting)
        {
            if (orangeSpeedBoostTimer <= 0f)
            {
                orangeSpeedBoostTimer = 2f;
                isBoosting = false;
                GetComponent<Bacteria2DController>().bactSpeed = playerSpeed;
            }
            else
            {
                orangeSpeedBoostTimer -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            foodCount++;
            foodCountText.text = "Food: " + foodCount.ToString();
            if (foodCount == MaxFood)
            {
                WinText.text = "YOU WON! CONGRATS!";
                gameManager.GetComponent<StateManager>().Invoke("EndGame", reloadSceneDelay);
            }
        }
        if (collision.tag == "Orange")
        {
            Destroy(collision.gameObject);
            isBoosting = true;
            GetComponent<Bacteria2DController>().bactSpeed += orangeSpeedBoost;
        }
    }
}
