using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] Slider loaderSlider;
    [SerializeField] [Range(0.1f, 1f)] float sliderSpeed = 0.5f;

    void Update()
    {
        loaderSlider.value += sliderSpeed * Time.deltaTime;

        if(loaderSlider.value >= 1f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
