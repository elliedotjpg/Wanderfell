using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    public float transformPositionX;
    public float transformPositionY;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        GameObject playerInstance = Instantiate(playerPrefab);
        Debug.Log("Player prefab instance created!");
        playerInstance.transform.position = transform.position + new Vector3(transformPositionX, transformPositionY);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
