using UnityEngine;

public class SimplePickup : MonoBehaviour
{
    public float pickupRange = 2f;
    public KeyCode pickupKey = KeyCode.E;

    private bool canPickup = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure your player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            canPickup = distanceToPlayer <= pickupRange;

            if (canPickup && Input.GetKeyDown(pickupKey))
            {
                PickupObject();
            }
        }
    }

    private void PickupObject()
    {
        Debug.Log("Picked up: " + gameObject.name);
        // Add your pickup logic here. For example:
        // - Add the item to inventory
        // - Destroy the object
        // - Play a sound effect
        // - Show a UI notification

        // For now, let's just destroy the object
        Destroy(gameObject);
    }
}
