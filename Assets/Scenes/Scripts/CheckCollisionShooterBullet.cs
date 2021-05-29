using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollisionShooterBullet : MonoBehaviour
{
    [SerializeField] private Text gameOverText;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private float reloadSceneDelay;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ShooterBullet")
        {
            gameObject.SetActive(false);
            gameOverText.text = "GAME OVER";
            gameManager.GetComponent<StateManager>().Invoke("EndGame", reloadSceneDelay);
        }
    }
}
