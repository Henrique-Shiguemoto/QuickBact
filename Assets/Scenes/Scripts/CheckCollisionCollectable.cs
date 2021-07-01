using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckCollisionCollectable : MonoBehaviour
{
    [SerializeField] private int foodCount = 0;
    [SerializeField] private Text foodCountText;
    [SerializeField] private Text WinText;
    [SerializeField] private float orangeSpeedBoost = 2.5f;
    [SerializeField] private float orangeSpeedBoostTimer = 2f;
    [SerializeField] private int MaxFood;
    [SerializeField] private float reloadSceneDelay;
    [SerializeField] private AudioSource collectSound;
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
            collectSound.Play();
            foodCount++;
            foodCountText.text = "Food: " + foodCount.ToString() + "/" + MaxFood.ToString();
            if (foodCount == MaxFood)
            {
                GameObject.Find("GameManager").GetComponent<StateManager>().PlaySound("winSound");
                WinText.text = "YOU WON! CONGRATS!";
                GameObject[] followers = GameObject.FindGameObjectsWithTag("Enemy");
                GameObject[] shooters = GameObject.FindGameObjectsWithTag("Shooter");
                GameObject[] shooterBullets = GameObject.FindGameObjectsWithTag("ShooterBullet");
                foreach (GameObject follower in followers)
                {
                    Destroy(follower);
                }
                foreach (GameObject shooter in shooters)
                {
                    Destroy(shooter);
                }
                foreach (GameObject bullet in shooterBullets)
                {
                    Destroy(bullet);
                }
                StartCoroutine(gameManager.GetComponent<StateManager>().LoadNextScene(SceneManager.GetActiveScene().buildIndex, reloadSceneDelay));
            }
        }
        if (collision.tag == "Orange")
        {
            Destroy(collision.gameObject);
            collectSound.Play();
            isBoosting = true;
            GetComponent<Bacteria2DController>().bactSpeed += orangeSpeedBoost;
        }
    }
}
