using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PauseGameWithKey();
    }

    private void PauseGameWithKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!pausePanel.activeSelf)
            {
                pausePanel.SetActive(true);
                Debug.Log("Game PAUSED!");
                Time.timeScale = 0f;
            }
            else //if (pausePanel != null)
            {
                pausePanel.SetActive(false);
                Debug.Log("Game UNPAUSED!");
                Time.timeScale = 1f;
            }
        }
            
    }

    public void PauseGameWithButton()
    {
        if (pausePanel != null)
        {
            bool isActive = pausePanel.activeSelf;
            pausePanel.SetActive(!isActive);
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Game PAUSED!");
        }
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        Debug.Log("Game UNPAUSED!");
 
    }
}
