using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextScene : MonoBehaviour
{
    public string sceneName;
    public Animator animator;

    public float delayTime = 1f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Player has collided with border!");
            //SceneManager.LoadScene(sceneName);
            FadeToLevel();
        }

    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
        Invoke("OnFadeComplete", delayTime);
        print("Fade complete!");
    }

    void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneName);
        print("Scene loaded!");
    }

}
