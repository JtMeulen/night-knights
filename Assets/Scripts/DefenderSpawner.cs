using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void OnMouseDown()
    {
        if (defender)
        {
            AttemptToPlaceDefender();
        }
    }

    private void AttemptToPlaceDefender()
    {
        SoulDisplay soulDisplay = FindObjectOfType<SoulDisplay>();
        int soulCost = defender.GetSoulCost();
        int totalSouls = soulDisplay.GetSoulsAmount();

        // Place defender if enough recourses
        if (soulCost <= totalSouls)
        {
            // Subtract the amount in the SoulDisplay
            soulDisplay.SubtractSouls(soulCost);
            // Place the defender on the grid
            Instantiate(defender, GetSquareClicked(), Quaternion.identity);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.x = Mathf.Round(worldPos.x);
        worldPos.y = Mathf.Round(worldPos.y);
        return worldPos;
    }
}
