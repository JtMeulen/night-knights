using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("SplashScreen details")]
    [SerializeField] int SplashScreenLoadTime = 1;
    [SerializeField] Slider loaderSlider;

    private int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if(currentScene == 0)
        {
            StartCoroutine(SplashScreenLoader());
        }
    }

    private void Update()
    {
        if (currentScene == 0 && loaderSlider)
        {
            SplashScreenLoadBar();
        }
        
    }

    private void SplashScreenLoadBar()
    {
        loaderSlider.value += (Time.deltaTime / SplashScreenLoadTime);
    }

    IEnumerator SplashScreenLoader()
    {
        yield return new WaitForSeconds(SplashScreenLoadTime);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver Screen");
    }
}
