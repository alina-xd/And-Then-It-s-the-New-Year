using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup cg;
    private bool fadein = false;
    private bool fadeout = false;

    public float duration;

    private void Start()
    {
        FadeIn();
    }

    void Update()
    {
        if (fadeout == true)
        {
            if (cg.alpha < 1)
            {
                cg.alpha += (float)1.0 / duration * Time.deltaTime;
                if (cg.alpha >= 1)
                {
                    fadeout = false;
                }
            }
        }
        if (fadein == true)
        {
            if (cg.alpha >= 0)
            {
                cg.alpha -= duration * Time.deltaTime;
                if (cg.alpha == 0)
                {
                    fadein = false;
                }
            }
        }
    }

    void FadeIn()
    {
        cg.alpha = 1;
        fadein = true;
    }

    void FadeOut()
    {
        cg.alpha = 0;
        fadeout = true;
    }

    public void Load(string name)
    {
        StartCoroutine(SwitchScene(name));
    }

    private IEnumerator SwitchScene(string scene)
    {
        FadeOut();
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(scene);
    }
}
