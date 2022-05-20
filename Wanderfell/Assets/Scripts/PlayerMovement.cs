using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private GameManager gameManager = new GameManager();

    private string sceneName; // = currentScene.name;
    Scene activeScene;
    Camera worldCamera;

    [SerializeField] private GroundDetector GroundDetector;

    public float MovementSpeed = 1f;
    public float JumpForce = 1;

    private Rigidbody2D rb;
    private Animator animator;
    //private int JumpCount;

    private float jumpHeight = 5f;

    //AudioSource ButtonSFX;

    Canvas errorPopUp;
    [SerializeField] private GameObject errorPopUpPrefab;

    public float delayTime = 3f;

    public float popUpTransformPositionX;
    public float popUpTransformPositionY;

    public GameObject activeDialogue;
    private GameObject errorInstance;
 

    private void Start()
    {
        //JumpCount = 0;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        MovementSpeed = 10f;

        activeScene = SceneManager.GetActiveScene();
        sceneName = activeScene.name;


        //errorPanel = GameObject.Find("errorPopUpPanel");
        //Debug.Log("Found error panel!");
        //print("Error Panel = " + errorPanel);
    }

    private void Update()
    {
        PlayerInput();

        animator.SetFloat("isJumping", rb.velocity.y);
        animator.SetFloat("isWalking", rb.velocity.x);
    }

    private void FixedUpdate()
    {
        activeDialogue = GameObject.FindWithTag("Dialogue");

    }

    private void PlayerInput()
    {
        transform.parent = null;

        // ------------------------------------ IF TRANSITION SCENE FOR PLAYERMOVEMENT ------------------------------------

        if ((sceneName == "oneTransition 1") || (sceneName == "twoTransition"))
        {
            Debug.Log("Transition scene confirmed!");

            if (Input.GetKey(KeyCode.A))
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
            else if (Input.GetKey(KeyCode.D))
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

            if (Input.GetKey(KeyCode.A))
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
            else if (Input.GetKey(KeyCode.D))
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

            if (Input.GetKey(KeyCode.A))
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
            else if (Input.GetKey(KeyCode.D))
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

            if (Input.GetKey(KeyCode.A))
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
            else if (Input.GetKey(KeyCode.D))
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

            if (Input.GetKey(KeyCode.A))
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
            else if (Input.GetKey(KeyCode.D))
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

            if (Input.GetKey(KeyCode.A))
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
            else if (Input.GetKey(KeyCode.D))
            {
                SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        // ------------------------------------ ELSE (IF) NOT TRANSITION SCENE FOR PLAYERMOVEMENT ------------------------------------

        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                SetMovement(-MovementSpeed, -Mathf.Abs(transform.localScale.x));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                SetMovement(MovementSpeed, Mathf.Abs(transform.localScale.x));
            }
            //else if (PlayerInput().GetKey(KeyCode.Return));
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

        }

        // Jump 
        if (Input.GetKeyDown(KeyCode.Space)) //|| (Input.GetKeyDown(KeyCode.Space) && JumpCount == 1))
        {
            //SoundManagerScript.PlaySound("jump");
            //JumpCount++;

            if(GroundDetector.IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
            
        }

        /**if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            JumpCount = 0;
        }*/

        else if (activeDialogue != null)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    void destroyInstance()
    {
        GameObject[] popUpInstances = GameObject.FindGameObjectsWithTag("ErrorPanel");

        foreach (GameObject popUpInstance in popUpInstances)
        {
            Destroy(popUpInstance);
        }

        
        Debug.Log("Pop up clones destroyed!");
    }

    private void SetMovement(float MovementSpeed, float faceDirection)
    {
        rb.velocity = new Vector2(MovementSpeed, rb.velocity.y);
        transform.localScale = new Vector3(faceDirection, transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stopPlayerHere"))
        {
            rb.velocity = new Vector3(0, 0, 0);
            MovementSpeed = 0;
            Debug.Log("Player will now stop here.");
        }
    }
}
