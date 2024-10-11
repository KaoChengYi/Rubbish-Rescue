using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowUIItems : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Animator DialogueUICanvas;
    public float waitTime;

    public void ShowItems()
    {
        FadeIn();
    }
    IEnumerator FadeIn()
    {
        SoundManager.PlaySound(SoundType.UIPLAY);
        DialogueUICanvas.SetTrigger("FadeIn");
        yield return new WaitForSeconds(waitTime);
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(true);
        }
    }
}
