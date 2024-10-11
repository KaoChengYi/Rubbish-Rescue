using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideUIItems : MonoBehaviour
{
    [SerializeField] private GameObject[] showGameObjects;
    [SerializeField] private GameObject[] hideGameObjects;
    [SerializeField] private Animator UICanvasAnimator;
    public float waitTime;

    public void ShowAndHideUIItems()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        SoundManager.PlaySound(SoundType.UIPLAY);
        UICanvasAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitTime);
        foreach (GameObject go in hideGameObjects)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in showGameObjects)
        {
            go.SetActive(true);
        }
    }
}