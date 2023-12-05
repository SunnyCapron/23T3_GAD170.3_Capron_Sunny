using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{

    [SerializeField] private GameObject playerCharacter;
    [SerializeField] private KeyCode keyToPress;
    [SerializeField] private bool isPlayerChatacterNearby = false;
    [SerializeField] private GameObject textLabel;
    [SerializeField] private GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerChatacterNearby = true;
            textLabel.SetActive(true);
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerChatacterNearby = false;
        textLabel.SetActive(false);
    }



    private void Update()
    {
        if (Input.GetKeyDown(keyToPress) && isPlayerChatacterNearby == true)
        {
            
            
            OpenDoor();

        }
    }

    private void OpenDoor()
    { 
        door.SetActive(false);
    
    }
}