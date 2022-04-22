using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameManager gameManager = new GameManager();

    public float MovementSpeed = 1;
    //public float JumpForce = 1;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    //private int JumpCount;

    private float jumpHeight = 5f;

    //AudioSource ButtonSFX;

    private void Start()
    {
        //JumpCount = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.GameState == GameManager.EnumGameState.Playing)
        {
            PlayerInput();
        }
        else
        {
            _rigidbody.velocity = new Vector2(1, 0);
        }
        _animator.SetFloat("Walk", Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetFloat("Jump", Mathf.Abs(_rigidbody.velocity.y));
    }

    private void PlayerInput()
    {
        transform.parent = null;

        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            SetMovement(-MovementSpeed, Mathf.Abs(transform.localScale.x));
        }

        // Move Right
        else if (Input.GetKey(KeyCode.D))
        {
            SetMovement(MovementSpeed, -Mathf.Abs(transform.localScale.x));
        }
        else
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        // Jump 
        if (Input.GetKeyDown(KeyCode.Space)) //|| (Input.GetKeyDown(KeyCode.Space) && JumpCount == 1))
        {
            //SoundManagerScript.PlaySound("jump");
            //JumpCount++;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpHeight);
        }

        /**if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            JumpCount = 0;
        }*/

    }

    private void SetMovement(float MovementSpeed, float faceDirection)
    {
        _rigidbody.velocity = new Vector2(MovementSpeed, _rigidbody.velocity.y);
        transform.localScale = new Vector3(faceDirection, transform.localScale.y, transform.localScale.z);
    }
}
