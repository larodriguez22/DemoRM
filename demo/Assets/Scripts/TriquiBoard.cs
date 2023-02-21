using UnityEngine;
using UnityEngine.Events;

public class TriquiBoard : MonoBehaviour
{
    public Collider winCollider; // This should be a reference to the collider that covers the correct part of the board.

    public UnityEvent OnWinConditionMet;
    
    private bool isPlayerOnWinCollider = false;

    private void OnTriggerStay(Collider other)

    {
        // Check if the player is inside the win collider.
        if (other == winCollider)
        {
            isPlayerOnWinCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player has left the win collider.
        if (other == winCollider)
        {
            isPlayerOnWinCollider = false;
        }
    }

    // Call this function to check if the player has completed the puzzle.
    public bool CheckWinCondition()
    {
        if (isPlayerOnWinCollider)
        {
            // Trigger the OnWinConditionMet event.
            OnWinConditionMet.Invoke();
            return isPlayerOnWinCollider;
        }
        else
        {
            return isPlayerOnWinCollider;
        }
    }
}
