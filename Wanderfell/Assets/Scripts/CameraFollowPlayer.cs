                                            using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform target;
    public float FollowSpeed = 2f;
    
    public float xOffset = 5f;
    public float yOffset = 2f;

    //public float borderXPosition = 1f;
    public float moveXOffset = 1f;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        target = player.transform;
      
        transform.position = new Vector3(target.position.y, target.position.x);
        print("Camera is now following player!");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            print("Border reached!");
            Vector3 movePos = new Vector3(target.position.x + moveXOffset, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, movePos, FollowSpeed * Time.deltaTime);
        }
    }
}