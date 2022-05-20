using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;

    [SerializeField] private Animator layoutAnimator;

    //public PlayerMovement movePlayer;
    public Rigidbody2D rb;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    public TextAsset inkJSON;

    private const string speakerTag = "speaker";
    private const string portraitTag = "portrait";
    private const string layoutTag = "layout";

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one dialogue manager in the scene.");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        //rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        currentStory = new Story(inkJSON.text);
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        } 

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            string currentSentence = currentStory.Continue();
            dialogueText.text = currentSentence;

            //currentStory.Continue();
            Debug.Log("Continue text!");

            rb.velocity = new Vector2(0, rb.velocity.y);
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    public void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch(tagKey)
            {
                case speakerTag:
                    displayNameText.text = tagValue;
                    break;
                case portraitTag:
                    portraitAnimator.Play(tagValue);
                    break;
                case layoutTag:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled:  " + tag);
                    break;
            }
        }
    }
}
