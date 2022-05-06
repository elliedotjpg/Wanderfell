using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform spawnPoint;
    public GameObject playerPrefab;

    Vector2 playerInitPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerInitPosition = FindObjectOfType<PlayerMovement>().transform.position;
    }

    private void Awake()
    {
        instance = this;
    }

    /**private spawnPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

    public void Spawn()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
