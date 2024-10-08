using UnityEngine;

public class Object : MonoBehaviour
{
    public string objectName = "Item";
    public KeyCode pickupKey = KeyCode.E;

    private bool playerInRange = false;
    private PlayerInventory playerInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = other.GetComponent<PlayerInventory>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerInventory = null;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(pickupKey) && playerInventory != null)
        {
            playerInventory.PickupItem(objectName);
            Destroy(gameObject);
        }
    }
}