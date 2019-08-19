using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown()
    {
       Instantiate(defender, GetSquareClicked(), Quaternion.identity);
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
