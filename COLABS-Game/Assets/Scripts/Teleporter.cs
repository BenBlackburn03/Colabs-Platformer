using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportDestination; // Set this in the Inspector to the default destination where you want to teleport the player
    public Transform customTeleportDestination; // Set this in the Inspector to a custom destination

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        // Use the customTeleportDestination if it is assigned, otherwise use the default teleportDestination
        Transform destination = customTeleportDestination != null ? customTeleportDestination : teleportDestination;

        player.transform.position = destination.position;
        // You may want to do additional things here, such as playing a teleportation sound, etc.
    }
}