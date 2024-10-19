using UnityEngine;

public class ShellCollectionManager : MonoBehaviour
{
    public int totalShells; // Set this in the Inspector to the total number of shells in your game
    public FinishScreenPanel finishScreen;
    public Inventory playerInventory;

    private int collectedShells = 0;

    private void Start()
    {
        // Ensure the finish screen is not visible at the start
        finishScreen.gameObject.SetActive(false);
    
     
        // Assuming the Inventory script is attached to the Player
        GameObject player = GameObject.FindWithTag("Player");  // Find the player GameObject
    playerInventory = player.GetComponent<Inventory>();    // Get the Inventory component from the player

        if (playerInventory == null)
        {
            Debug.LogError("Player Inventory not found!");
        }
    }
    public void CollectShell()
    {
        collectedShells++;

        // Check if all shells have been collected
        if (collectedShells >= totalShells)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // Show the finish screen with the total number of shells collected
        finishScreen.ShowFinishScreen(collectedShells);
    }
}
