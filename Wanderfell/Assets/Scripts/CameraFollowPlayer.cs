                                            using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform target;
    //public float smoothTime = 2F;

    public float FollowSpeed = 2f;

    private GameObject player;
    
    public float xOffset = 5f;
    public float yOffset = 3f;
    public float zConstant = 200f;

    private Vector3 velocity;

    //public float borderXPosition = 1f;
    public float moveXOffset = 1f;

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
        target = player.transform;
        //transform.position = new Vector3(target.position.y, target.position.x, -10f);

        //Vector3 oldPos = new Vector3(player.transform.position.x, player.transform.position.y, -10f);

        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);

        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            print("Border reached!");
            Vector3 movePos = new Vector3(target.position.x + moveXOffset, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(player.transform.position, movePos, FollowSpeed * Time.deltaTime);
        }
    }
}