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

    public float MovementSpeed = 1f;
    //public float JumpForce = 1;

    private Rigidbody2D rb;
    private Animator animator;
    //private int JumpCount;

    private float jumpHeight = 5f;

    //AudioSource ButtonSFX;

    Canvas errorPopUp;
    [SerializeField] private GameObject errorPopUpPrefab;

    public float delayTime = 2f;

    public float popUpTransformPositionX;
    public float popUpTransformPositionY;

    //public Camera cameraToUse;
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
        /**else
         {
             rigidbody.velocity = new Vector2(1, 0);
         }
        **/
        animator.SetFloat("isJumping", rb.velocity.y);
        animator.SetFloat("isWalking", rb.velocity.x);
    }

    private void FixedUpdate()
    {
        //destroyPopup = GameObject.FindWithTag("ErrorPanel");
        
    }

    private void PlayerInput()
    {
        transform.parent = null;

        // Move Left
        if ((sceneName == "oneTransition") || (sceneName == "twoTransition"))
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
                                      
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        /**if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            JumpCount = 0;
        }*/

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
}
