                                            using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform target;

    public float FollowSpeed = 2f;
    public float delayTime = 10f;

    private GameObject player;
    
    public float xOffset = 5f;
    public float yOffset = 3f;
    public float zConstant = 200f;

    private Vector3 velocity;

    public float moveXOffset = 1f;
    public float moveYOffset = 1f;

    public Collider2D mainCameraCollider;

    private bool detectBorder;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (player!= null) {
            return;
         }

        player = GameObject.FindWithTag("Player");
        Debug.Log("Game object with specified tag has been found!");
        print("player = " + player);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Invoke("TurnOnCollider", delayTime);

        if (detectBorder == true)
        {
            Vector3 movePos = new Vector3(target.position.x + moveXOffset, target.position.y + moveYOffset, -5f);
            print(target.position.x);
            Debug.Log("Moving X Offset!");

            transform.position = Vector3.Slerp(transform.position, movePos, FollowSpeed * Time.deltaTime);
        }
        else
        {
            target = player.transform;

            Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -5f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }

    void TurnOnCollider()
    {
        if (mainCameraCollider.enabled == false)
        {
            mainCameraCollider.enabled = true;
            Debug.Log("Collider enabled!");
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Border")
        {
            detectBorder = true;
            print("Border reached!");
        }
    }
}