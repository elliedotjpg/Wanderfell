using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is a basic 2D character controller that allows
// the player to run and jump. It uses Unity's new input system,
// which needs to be set up accordingly for directional movement
// and jumping buttons.

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    /**
    [Header("Movement Params")]
    public float runSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravityScale = 1f;

    private Animator animator;

    private string sceneName;
    Scene activeScene;

    // components attached to player
    private CapsuleCollider2D coll;
    private Rigidbody2D rb;

    // other
    private bool isGrounded = false;
    Canvas errorPopUp;
    [SerializeField] private GameObject errorPopUpPrefab;

    public float delayTime = 3f;

    public float popUpTransformPositionX;
    public float popUpTransformPositionY;

    private void Update()
    {
        animator.SetFloat("isJumping", rb.velocity.y);
        animator.SetFloat("isWalking", rb.velocity.x);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = gravityScale;

        activeScene = SceneManager.GetActiveScene();
        sceneName = activeScene.name;
    }

    private void FixedUpdate()
    {

        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        UpdateIsGrounded();

        HandleHorizontalMovement();

        HandleJumping();
    }

    private void UpdateIsGrounded()
    {
        Bounds colliderBounds = coll.bounds;
        float colliderRadius = coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        // Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        this.isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != coll)
                {
                    this.isGrounded = true;
                    break;
                }
            }
        }
    }

    private void HandleHorizontalMovement()
    {
        if ((sceneName == "oneTransition 1") || (sceneName == "twoTransition"))
        {
            Debug.Log("Transition scene confirmed!");

            if (InputManager.GetInstance().GetWalkLeft())
            {
                errorInstance = Instantiate(errorPopUpPrefab);
                Debug.Log("Error pop up instance created!");
                errorInstance.transform.position = transform.position + new Vector3(popUpTransformPositionX, popUpTransformPositionY);

                Camera cameraToUse = Camera.main;
                errorPopUp = errorInstance.GetComponent<Canvas>();

                errorPopUp.worldCamera = cameraToUse;

                Invoke("destroyInstance", delayTime);
                //int popUpCount = destroyPopUp.Length;


            }
            else if (InputManager.GetInstance().GetWalkRight())
            {
                SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        else if ((sceneName == "threeTransition") || (sceneName == "fourTransition"))
        {
            Debug.Log("Transition scene confirmed!");

            if (InputManager.GetInstance().GetWalkLeft())
            {
                errorInstance = Instantiate(errorPopUpPrefab);
                Debug.Log("Error pop up instance created!");
                errorInstance.transform.position = transform.position + new Vector3(popUpTransformPositionX, popUpTransformPositionY);

                Camera cameraToUse = Camera.main;
                errorPopUp = errorInstance.GetComponent<Canvas>();

                errorPopUp.worldCamera = cameraToUse;

                Invoke("destroyInstance", delayTime);
                //int popUpCount = destroyPopUp.Length;


            }
            else if (InputManager.GetInstance().GetWalkRight())
            {
                SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        else if ((sceneName == "fiveTransition") || (sceneName == "sixTransition"))
        {
            Debug.Log("Transition scene confirmed!");

            if (InputManager.GetInstance().GetWalkLeft())
            {
                errorInstance = Instantiate(errorPopUpPrefab);
                Debug.Log("Error pop up instance created!");
                errorInstance.transform.position = transform.position + new Vector3(popUpTransformPositionX, popUpTransformPositionY);

                Camera cameraToUse = Camera.main;
                errorPopUp = errorInstance.GetComponent<Canvas>();

                errorPopUp.worldCamera = cameraToUse;

                Invoke("destroyInstance", delayTime);
                //int popUpCount = destroyPopUp.Length;
            }
            else if (InputManager.GetInstance().GetWalkRight())
            {
                SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        else if ((sceneName == "sevenTransition") || (sceneName == "eightTransition"))
        {
            Debug.Log("Transition scene confirmed!");

            if (InputManager.GetInstance().GetWalkLeft())
            {
                errorInstance = Instantiate(errorPopUpPrefab);
                Debug.Log("Error pop up instance created!");
                errorInstance.transform.position = transform.position + new Vector3(popUpTransformPositionX, popUpTransformPositionY);

                Camera cameraToUse = Camera.main;
                errorPopUp = errorInstance.GetComponent<Canvas>();

                errorPopUp.worldCamera = cameraToUse;

                Invoke("destroyInstance", delayTime);
                //int popUpCount = destroyPopUp.Length;


            }
            else if (InputManager.GetInstance().GetWalkRight())
            {
                SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        else if ((sceneName == "nineTransition") || (sceneName == "tenTransition"))
        {
            Debug.Log("Transition scene confirmed!");

            if (InputManager.GetInstance().GetWalkLeft())
            {
                errorInstance = Instantiate(errorPopUpPrefab);
                Debug.Log("Error pop up instance created!");
                errorInstance.transform.position = transform.position + new Vector3(popUpTransformPositionX, popUpTransformPositionY);

                Camera cameraToUse = Camera.main;
                errorPopUp = errorInstance.GetComponent<Canvas>();

                errorPopUp.worldCamera = cameraToUse;

                Invoke("destroyInstance", delayTime);
                //int popUpCount = destroyPopUp.Length;


            }
            else if (InputManager.GetInstance().GetWalkRight())
            {
                SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        else if ((sceneName == "elevenTransition") || (sceneName == "twelveTransition"))
        {
            Debug.Log("Transition scene confirmed!");

            if (InputManager.GetInstance().GetWalkLeft())
            {
                errorInstance = Instantiate(errorPopUpPrefab);
                Debug.Log("Error pop up instance created!");
                errorInstance.transform.position = transform.position + new Vector3(popUpTransformPositionX, popUpTransformPositionY);

                Camera cameraToUse = Camera.main;
                errorPopUp = errorInstance.GetComponent<Canvas>();

                errorPopUp.worldCamera = cameraToUse;

                Invoke("destroyInstance", delayTime);
                //int popUpCount = destroyPopUp.Length;


            }
            else if (InputManager.GetInstance().GetWalkRight())
            {
                SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        else
        {
            if (InputManager.GetInstance().GetWalkLeft())
            {
                SetMovement(-MovementSpeed, -Mathf.Abs(transform.localScale.x));
            }
            else if (InputManager.GetInstance().GetWalkRight())
            {
                SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

    }
        // handle jumping
        private void HandleJumping()
        {
            bool jumpPressed = InputManager.GetInstance().GetJumpPressed();
            if (isGrounded && jumpPressed)
            {
                isGrounded = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }

        // Set movement 
        private void SetMovement(float MovementSpeed, float faceDirection)
        {
            //Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
            rb.velocity = new Vector2(moveDirection.x * runSpeed, rb.velocity.y);

            //rb.velocity = new Vector2(MovementSpeed, rb.velocity.y);
            transform.localScale = new Vector3(faceDirection, transform.localScale.y, transform.localScale.z);
    }*/
}