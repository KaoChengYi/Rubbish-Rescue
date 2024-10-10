using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameWithTransition : MonoBehaviour
{
    public float waitTime;
    public Animator musicAnim;
    public Animator transitionAnim;

    public void CloseGame()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        musicAnim.SetTrigger("FadeOut");
        transitionAnim.SetTrigger("SceneFadeOut");
        SoundManager.PlaySound(SoundType.UIPLAY);
        yield return new WaitForSeconds(waitTime);
        Application.Quit();
    }
}