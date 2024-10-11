using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUIItems : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Animator DialogueUICanvas;
    public float waitTime;

    public void HideItems()
    {
        FadeOut();
    }
    IEnumerator FadeOut()
    {
        SoundManager.PlaySound(SoundType.UIPLAY);
        DialogueUICanvas.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitTime);
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
    }
}