using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPressLoadSceneWithTransition : MonoBehaviour
{
    [SerializeField] string sceneName;

    public float waitTime;
    public Animator musicAnim;
    public Animator transitionAnim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ChangeScene());
        }
    }
    IEnumerator ChangeScene()
    {
        musicAnim.SetTrigger("FadeOut");
        transitionAnim.SetTrigger("SceneFadeOut");
        SoundManager.PlaySound(SoundType.UIPLAY);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}
