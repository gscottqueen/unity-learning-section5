using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnPoint;
    public CharacterController player;
 
    public Bonus bonusSpawner;
    public Bonus superBonusSpawner;
    private Boolean superBonus = false;

    private void OnTriggerEnter(Collider other) {
        // Collect pick ups
        if(other.CompareTag("Pick Up"))
        {
            Debug.Log("Pick up collected!");
            GameObject.Destroy(other.gameObject);

            if (bonusSpawner)
                bonusSpawner.gameObject.SendMessage("Pickup");

        }

        if (other.CompareTag("Super Pickup"))
        {
            Debug.Log("Super pick up collected!");
            GameObject.Destroy(other.gameObject);

            if (superBonusSpawner)
                superBonusSpawner.gameObject.SendMessage("SuperPickup");
                superBonus = true;
        }

        // Respawn after hitting fall zone if we are not in superBonus
        if (other.CompareTag("Fall Zone") && superBonus == false)
        {
            Debug.Log("Player has fallen out of bounds. Resetting position...");
            player.enabled = false;
            transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            player.enabled = true;
        }
    }
}
