using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public Animator animator;

    public float delayTime = 3f;

    void ClickButton()
    {
        FadeToLevel();

    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
        Invoke("OnFadeComplete", delayTime);
        print("Fade complete!");
        
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneName);
        print("Scene loading!");
    }
}