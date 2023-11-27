using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    // The name of the scene you want to load
    public int sceneToLoad = 1;

    // Called when the button is clicked
    public void StartScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
    
    
}
