using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

public enum SoundType
{
    //UICLICK,
    //UIPLAY,
    //UICHANGE,
    //GAMECORRECT,
    //GAMEWRONG,
    //GAMECONGRATS,

    PICKUPITEM,
    //USE,
    //PICKUPPAPER,
    //PICKUPGLASS,
    //PICKUPPLASTIC,
    //PICKUPTRASH,

    //DRUMMER,
}

// audio source is always required
[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;

    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one SoundManager in the scene.");
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound)
    {
        // do not play if audio source not found
        if (instance.audioSource == null)
        {
            Debug.LogWarning("SoundManager: No AudioSource detected - sound not played " + sound.ToString());
            return;
        }

        // load SoundList to play
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        // get volume and pitch
        float volumeVariance = instance.soundList[(int)sound].VolumeVariance;
        float volume = instance.soundList[(int)sound].Volume * (1 + UnityEngine.Random.Range(-volumeVariance / 2f, volumeVariance / 2f));
        //float pitchVariance = instance.soundList[(int)sound].PitchVariance;
        //float pitch = instance.soundList[(int)sound].Pitch * (1 + UnityEngine.Random.Range(-pitchVariance / 2f, pitchVariance / 2f));

        // do not play if no clips added to SoundList
        if (clips.Length <= 0)
        {
            Debug.LogWarning("SoundManager: No sound clips detected in SoundList - sound not played " + sound.ToString());
            return;
        }
        if (volume == 0) Debug.LogWarning("SoundManager: Volume is set to 0 for sound " + sound.ToString());

        // play random sound from SoundList
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, volume);
        Debug.Log("SoundManager: attempted to play sound " + sound.ToString() + " at volume " + volume.ToString());
        //Debug.Log("SoundManager: attempted to play sound " + sound.ToString() + " at volume " + volume.ToString() + " and pitch " + pitch.ToString());
    }

    // only execute if in unity editor
#if UNITY_EDITOR
    private void OnEnable()
    {
        // set sound names in inspector
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);

        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
#endif
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
    [Range(0f, 2f)] public float Volume;
    //[Range(0.5f, 1.5f)] public float Pitch;
    [Range(0f, 0.5f)] public float VolumeVariance;
    //[Range(0f, 0.5f)] public float PitchVariance;
}
