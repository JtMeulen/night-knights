using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winText;
    [SerializeField] GameObject gameOverOverlay;
    [SerializeField] int SecondsToWaitForNewLevel = 2;
    private int activeAttackers = 0;
    private bool levelTimerFinished = false;

    private void Start()
    {
        winText.SetActive(false);
        gameOverOverlay.SetActive(false);
    }

    public void AttackerSpawned()
    {
        activeAttackers++;
    }

    public void AttackerKilled()
    {
        activeAttackers--;

        if(activeAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(WinLevelCoroutine());
        }
    }

    IEnumerator WinLevelCoroutine()
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(SecondsToWaitForNewLevel);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    public void FinishTimer()
    {
        levelTimerFinished = true;
        StopSpawning();
    }

    private void StopSpawning()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        StopSpawning();
        gameOverOverlay.SetActive(true);
    }


}
