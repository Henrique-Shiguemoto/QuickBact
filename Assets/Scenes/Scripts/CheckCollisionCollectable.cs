using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollisionCollectable : MonoBehaviour
{
    [SerializeField] private int foodCount = 0;
    [SerializeField] private Text foodCountText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            foodCount++;
            foodCountText.text = "Food: " + foodCount.ToString();
        }
    }
}
