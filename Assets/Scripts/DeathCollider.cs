using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public int sceneToload;
        public void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Unlock and show the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Reload the title scene
            SceneManager.LoadScene(sceneToload);
        }
    }
}