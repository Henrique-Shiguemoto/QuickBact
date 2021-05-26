using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollisionHole : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private float reloadSceneDelay;
    [SerializeField] private Text gameOverText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hole")
        {
            gameObject.SetActive(false);
            gameOverText.text = "GAME OVER";
            gameManager.GetComponent<StateManager>().Invoke("EndGame", reloadSceneDelay);
        }
    }

}
