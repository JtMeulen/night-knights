using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    Color32 darkColor = new Color32(50, 50, 50, 255);
    Color32 whiteColor = new Color32(255, 255, 255, 255);

    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        GetComponentInChildren<Text>().text = defenderPrefab.GetSoulCost().ToString();
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = darkColor;
        }

        GetComponent<SpriteRenderer>().color = whiteColor;

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
