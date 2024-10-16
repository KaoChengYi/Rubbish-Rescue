using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionWithMusic : MonoBehaviour
{
    // Name of the scene to load
    public string sceneName;

    //private static MusicTransition instance;

    public float waitTime;
    public Animator musicAnim;
    public Animator transitionAnim;

    public void LoadNextScene()
    {
        // start coroutine to fade out music
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        musicAnim.SetTrigger("FadeOut");
        transitionAnim.SetTrigger("SceneFadeOut");
        SoundManager.PlaySound(SoundType.UIPLAY);
        yield return new WaitForSeconds(waitTime);
        // Load the scene specified in the sceneName variable
        SceneManager.LoadScene(sceneName);
    }
}
