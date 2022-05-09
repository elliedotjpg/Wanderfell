using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopHere : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            Debug.Log("Player will now stop here.");
            
        }
    }
}
