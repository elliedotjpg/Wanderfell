using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNewScene : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab = null;

    public float transformPositionX;
    public float transformPositionY;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerInstance = Instantiate(playerPrefab);

        playerInstance.transform.position = transform.position + new Vector3(transformPositionX, transformPositionY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
