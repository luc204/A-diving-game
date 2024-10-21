using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public Text countText; // UI Text to display the count
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    private Inventory PlayerInventory;

    public void PickupItem(string Shells)
    {
        if (inventory.ContainsKey(Shells))
        {
            inventory[Shells]++;
        }
        else
        {
            inventory[Shells] = 1;
        }
        UpdateCountDisplay();
        Debug.Log($"Picked up {Shells}. Total: {inventory[Shells]}");
    }

    private void UpdateCountDisplay()
    {
        string displayText = "";
        foreach (var item in inventory)
        {
            displayText += $"{item.Key}: {item.Value}\n";
        }
        if (countText != null)
        {
            countText.text = displayText;
        }
    }
}