using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulDisplay : MonoBehaviour
{
    [SerializeField] int souls = 100;
    Text soulText;

    private void Start()
    {
        soulText = GetComponent<Text>();
        UpdateSoulDisplay();
    }

    private void UpdateSoulDisplay()
    {
        soulText.text = souls.ToString();
    }

    public void AddSouls(int amount)
    {
        souls += amount;
        UpdateSoulDisplay();
    }

    public void SubtractSouls(int amount)
    {
        souls -= amount;
        UpdateSoulDisplay();
    }

    public int GetSoulsAmount()
    {
        return souls;
    }
}
