using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject map;
    private bool mapIsShowing;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!mapIsShowing)
            {
                map.SetActive(true);
                mapIsShowing = true;
            }
            else
            {
                map.SetActive(false);
                mapIsShowing = false;
            }
        }
    }
}
