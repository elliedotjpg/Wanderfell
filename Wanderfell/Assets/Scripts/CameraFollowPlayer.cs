                                            using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform target;

    public float FollowSpeed = 2f;
    public float delayTime = 3f;

    private GameObject player;
    
    public float xOffset = 5f;
    public float yOffset = 3f;
    public float zConstant = 200f;

    private Vector3 velocity;

    public float moveXOffsetToLeft = 1f;
    public float moveYOffsetToLeft = 1f;

    public float moveXOffsetToRight = 1f;
    public float moveYOffsetToRight = 1f;

    public Collider2D mainCameraCollider;

    private bool detectRightBorder;
    private bool detectLeftBorder;

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

        target = player.transform;

        if (detectRightBorder == true)
        {
            Vector3 movePos = new Vector3(target.position.x + moveXOffsetToLeft, target.position.y + moveYOffsetToLeft, -5f);

            Debug.Log("Moving X Offset to the LEFT!");

            transform.position = Vector3.Slerp(transform.position, movePos, FollowSpeed * Time.deltaTime);
        }
            
        if (detectLeftBorder == true)
        { 

            Vector3 hitLeftBorderPos = new Vector3(target.position.x + moveXOffsetToRight, target.position.y + moveYOffsetToRight, -5f);

            Debug.Log("Moving X Offset to the RIGHT!");

            transform.position = Vector3.Slerp(transform.position, hitLeftBorderPos, FollowSpeed * Time.deltaTime);
        }

        else
        {
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

        if (collision.gameObject.tag == "rightBorder")
        {
            detectRightBorder = true;
            print("Right border reached!");
        }

        else
        {
            if (collision.gameObject.tag == "leftBorder")
            {
                detectLeftBorder = true;
                Debug.Log("Left border reached!");
            }
        }
    }
}