using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bonus : MonoBehaviour
{   
    // counter for the remaining collectables in the scene
    public int counter;
    private GameObject[] pickups;
    private GameObject[] fallzones;

    // the prefab that will be instantiated
    public GameObject bonusObject;


    // Start is called before the first frame update
    void Start()
    {
        // get all objects with tag "Pick up"
        pickups = GameObject.FindGameObjectsWithTag("Pick Up");
        counter = pickups.Length;
        fallzones = GameObject.FindGameObjectsWithTag("Fall Zone");

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void Pickup()
    {
        Debug.Log("Pick up Message Recieved");
        counter--;

        if (counter == 0)
            SpawnBonus();
    }

    public void SuperPickup()
    {
        Debug.Log("Super pick up message recieved");
        // destroy all the pickup game objects
        for (int i = 0; i < pickups.Length; i ++)
        {
            Destroy(pickups[i]);
        }
        // shut off trigger for fallzones
        SpawnBonus();
    }

    void SpawnBonus()
    {
        // Instantiate our Prefab
        GameObject.Instantiate(bonusObject, transform);
    }
}
