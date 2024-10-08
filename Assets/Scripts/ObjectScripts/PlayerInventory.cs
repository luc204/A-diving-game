using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public Text countText; // UI Text to display the count
    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    public void PickupItem(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName]++;
        }
        else
        {
            inventory[itemName] = 1;
        }
        UpdateCountDisplay();
        Debug.Log($"Picked up {itemName}. Total: {inventory[itemName]}");
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