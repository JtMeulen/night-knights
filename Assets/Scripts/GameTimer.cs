using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] float levelTime = 10f;

    private bool triggerFinishedTimer = false;

    private void Update()
    {
        if (triggerFinishedTimer) { return; }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        if (Time.timeSinceLevelLoad >= levelTime)
        {
            FindObjectOfType<LevelController>().FinishTimer();
            triggerFinishedTimer = true;
        }
    }
}
