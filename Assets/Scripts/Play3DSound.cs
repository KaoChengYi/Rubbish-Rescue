using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play3DSound : MonoBehaviour
{
    private SoundManager soundMgr;
    private AudioSource audioSource;

    private void Awake()
    {
        soundMgr = FindObjectOfType<SoundManager>();
        if (soundMgr == null)
        {
            Debug.LogError("Play3DSound: Sound Manager failed to load on object " + this.gameObject.name);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundType soundType)
    {
        if (audioSource == null)
        {
            Debug.LogWarning("SoundManager: No AudioSource detected - 3D sound not played for " + this.gameObject.name);
            return;
        }
        SoundManager.Play3DSound(soundType, audioSource);
    }
}
