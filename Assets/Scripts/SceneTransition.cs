using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Name of the scene to load
    public string sceneName;

    public void LoadNextScene()
    {
        // Load the scene specified in the sceneName variable
        SceneManager.LoadScene(sceneName);
    }
}
