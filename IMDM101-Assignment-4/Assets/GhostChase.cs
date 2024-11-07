using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

// This script makes multiple ghost enemies follow the player

public class GhostChase : MonoBehaviour
{
    public GameObject[] ghosts; // Array to hold references to the ghosts
    public GameObject player;   // Reference to the player GameObject
    public float speed = 2.0f;  // Speed at which each ghost will move
    float count;
    int interval;

    void Start()
    {
        count = 0;
        interval = 15;

        // Check if player is assigned
        if (player == null)
        {
            Debug.LogError("Player not assigned in the Inspector!");
        }

        // Check if ghosts array is populated
        if (ghosts.Length == 0)
        {
            Debug.LogError("No ghosts assigned to the ghosts array in the Inspector!");
        }
    }

    void Update()
    {
        // will increase the ghost speed every x seconds, where x decreases as time goes on
        count += Time.deltaTime;
        if(count >= interval)
        {
            count -= interval;
            speed++;
            if(speed == 4f)
            {
                interval = 10;
            }
            else if (speed == 7f)
            {
                interval = 7;
            }
        }

        if (player != null)
        {
            foreach (GameObject ghost in ghosts)
            {
                if (ghost != null)
                {
                    // Make the ghost look at the player
                    ghost.transform.LookAt(player.transform.position);

                    // Calculate direction to player
                    Vector3 targetDirection = player.transform.position - ghost.transform.position;

                    // Move the ghost toward the player
                    ghost.GetComponent<Rigidbody>().velocity = targetDirection.normalized * speed;
                }
            }
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("CapsulePlayer"))
    //    {
    //        SceneManager.LoadScene("Laboratory Scene");
    //    }
    //}

}
