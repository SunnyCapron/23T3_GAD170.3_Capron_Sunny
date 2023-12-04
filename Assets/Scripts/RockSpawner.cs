using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    // need to make a falling rock that spanws at a random spawn point
    //player collison
    // instantition of game object
    // location refernce to spawn points
     
    
    
    [SerializeField] private GameObject fallingRockPrefab;

    [SerializeField] private List<GameObject> rockSpawnPoints = new List<GameObject>();
    [SerializeField] private List<Rock> rocks = new List<Rock>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            Debug.Log("collison!");

            Vector3 spawnPosition = rockSpawnPoints[Random.Range(0,5)].transform.position;
            //check that variable is not null

            if (fallingRockPrefab != null) 
            { 
            GameObject newrock = Instantiate(fallingRockPrefab, spawnPosition, Random.rotation);

            rocks.Add(newrock.GetComponent<Rock>());

                foreach (Rock rock in rocks)
                {
                  rock.name = "Falling Rock";
                }
            }
        }
    }
}
