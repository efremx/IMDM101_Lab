using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // Assign your player object here in the Inspector
    public float speed = 3.0f; // Speed at which the enemy will move toward the player

    // Called when the script is initialized
    void Start()
    {
        // Check if the player reference is assigned
        if (player == null)
        {
            Debug.LogError("Player not assigned in the Inspector!");
        }
    }

    // Called once per frame
    void Update()
    {
        if (player != null)
        {
            // Calculate direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the enemy in the direction of the player at the specified speed
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
