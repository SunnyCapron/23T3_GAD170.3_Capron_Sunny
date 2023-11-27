using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterPad : MonoBehaviour
{

    [SerializeField] private GameObject playerCharacter;
    [SerializeField] private int sceneToLoad;
    [SerializeField] private KeyCode keyToPress;
    [SerializeField] private bool isPlayerChatacterNearby = false;
    [SerializeField] private GameObject textLabel;

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
            
            
            ActivateTeleporter();

        }
    }

    private void ActivateTeleporter()
    { 
        SceneManager.LoadScene(sceneToLoad);
    
    }
}
