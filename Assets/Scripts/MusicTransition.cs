using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransition : MonoBehaviour
{
    private static MusicTransition instance;

    public float waitTime;
    public Animator musicAnim;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ChangeScene()
    {
        musicAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitTime);
    }
}
