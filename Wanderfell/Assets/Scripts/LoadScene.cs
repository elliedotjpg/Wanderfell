using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public Animator animator;

    public float delayTime = 5f;

    int notes = 0;

    void ClickButton()
    {
        if (notes == 3)
        {
            Invoke("DelayedAction", delayTime);
        }
    }

    public void DelayedAction()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
}