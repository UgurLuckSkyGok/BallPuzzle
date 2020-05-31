using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Singleton<LevelLoader>
{
    public Animations selected;

    public Animator CrossFade;
    public Animator CircleWipe;
    public Animator OpenLogo;
    Animator selectedAnimation;
    public float animationTime;

    public enum Animations
    {
        CrossFade,
        CircleWipe,
        OpenLogo
    }

    public void Start()
    {
        switch (selected)
        {
            case Animations.CrossFade:
                CrossFade.gameObject.SetActive(true);
                selectedAnimation = CrossFade;
                break;
            case Animations.CircleWipe:
                CircleWipe.gameObject.SetActive(true);
                selectedAnimation = CircleWipe;
                break;
            case Animations.OpenLogo:
                OpenLogo.gameObject.SetActive(true);
                selectedAnimation = OpenLogo;
                break;
        }

		//if (SceneManager.GetActiveScene().buildIndex == 0)
          //  selectedAnimation.enabled = false;
    }

    public void NextScene(string sceneName)
    {
        StartCoroutine(LevelLoaderIE(sceneName));
    }

    IEnumerator LevelLoaderIE(string sceneName)
    {
        selectedAnimation.enabled = true;
        selectedAnimation.SetTrigger("Start");
        yield return new WaitForSeconds(animationTime);
        SceneManager.LoadScene(sceneName);

    }

}
