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
