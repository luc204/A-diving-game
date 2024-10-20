using UnityEngine;

public class Object : MonoBehaviour
{
    public string objectName = "Shells";
    public KeyCode pickupKey = KeyCode.E;

    private bool playerInRange = false;
    private Inventory playerInventory;

    AudioManager audioManager;

    public void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = other.GetComponent<Inventory>();
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



    public void Update()
    {
        if (playerInRange && Input.GetKeyDown(pickupKey) && playerInventory != null)
        {
           
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.PickUp);
            }


            playerInventory.PickupItem(objectName);
            Destroy(gameObject);
        }
    }
}