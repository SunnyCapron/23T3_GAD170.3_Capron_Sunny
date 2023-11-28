using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private bool isPlayerCharacterNearby = false;
    [SerializeField] private GameObject textLabel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerCharacterNearby = true;
            textLabel.SetActive(true);
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerCharacterNearby = false;
        textLabel.SetActive(false);
    }
}
