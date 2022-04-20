using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollowPlayer : MonoBehaviour
{

    public float FollowSpeed = 2f;
    public Transform target;
    public float yOffset = 1f;

    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y + yOffset);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}