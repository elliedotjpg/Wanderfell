using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnError : MonoBehaviour
{
    [SerializeField] private GameObject errorPopUpPrefab;

    public float transformPositionX;
    public float transformPositionY;


    // Start is called before the first frame update
    void Start()
    {
        GameObject errorInstance = Instantiate(errorPopUpPrefab);
        Debug.Log("Error pop up instance created!");
        errorInstance.transform.position = transform.position + new Vector3(transformPositionX, transformPositionY);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
