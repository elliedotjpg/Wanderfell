using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameManager gameManager = new GameManager();

    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private int JumpCount;
    public int Score;

    AudioSource ButtonSFX;

    private void Start()
    {
        JumpCount = 0;
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
            _rigidbody.velocity = new Vector2(0, 0);
        }
        _animator.SetFloat("Run", Mathf.Abs(_rigidbody.velocity.x));
    }

    private void PlayerInput()
    {
        transform.parent = null;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SetMovement(-MovementSpeed, -Mathf.Abs(transform.localScale.x));
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
        }
        else
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        // Jump 
        if ((Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) || (Input.GetButtonDown("Jump") && JumpCount == 1))
        {
            SoundManagerScript.PlaySound("jump");
            JumpCount++;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            JumpCount = 0;
        }

    }

    private void SetMovement(float MovementSpeed, float faceDirection)
    {
        _rigidbody.velocity = new Vector2(MovementSpeed, _rigidbody.velocity.y);
        transform.localScale = new Vector3(faceDirection, transform.localScale.y, transform.localScale.z);
    }
}
