using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameManager gameManager = new GameManager();

    public float MovementSpeed = 1f;
    //public float JumpForce = 1;

    private Rigidbody2D rb;
    private Animator animator;
    //private int JumpCount;

    private float jumpHeight = 5f;

    //AudioSource ButtonSFX;

    private void Start()
    {
        //JumpCount = 0;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        MovementSpeed = 3f;
    }

    private void Update()
    {
        PlayerInput();
        /**else
         {
             rigidbody.velocity = new Vector2(1, 0);
         }
        **/
        animator.SetFloat("isJumping", rb.velocity.y);
        animator.SetFloat("isWalking", rb.velocity.x); 
    }

    private void PlayerInput()
    {
        transform.parent = null;

        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            SetMovement(-MovementSpeed, -Mathf.Abs(transform.localScale.x));
        }


        else if (Input.GetKey(KeyCode.D))
        {
            SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Jump 
        if (Input.GetKeyDown(KeyCode.Space)) //|| (Input.GetKeyDown(KeyCode.Space) && JumpCount == 1))
        {
            //SoundManagerScript.PlaySound("jump");
            //JumpCount++;
            
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        /**if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            JumpCount = 0;
        }*/

    }

    private void SetMovement(float MovementSpeed, float faceDirection)
    {
        rb.velocity = new Vector2(MovementSpeed, rb.velocity.y);
        transform.localScale = new Vector3(faceDirection, transform.localScale.y, transform.localScale.z);
    }
}
