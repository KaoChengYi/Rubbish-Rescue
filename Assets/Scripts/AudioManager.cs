using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 2f)]
    public float volume = 0.7f;
    [Range(0.5f,1.5f)]
    public float pitch = 1f;

    [Range(0f, 0.5f)]
    public float volumeVariance = 0.1f;
    [Range(0f, 0.5f)]
    public float pitchVariance = 0.1f;

    private AudioSource source;

    public void SetSource(AudioSource _audioSource)
    {
        source = _audioSource;
        source.clip = clip;
    }

    public void Play()
    {
        // randomise pitch, volume for repetitive/UI sounds
        source.volume = volume * (1 + UnityEngine.Random.Range(-volumeVariance/2f,volumeVariance/2f));
        source.pitch = pitch * (1 + UnityEngine.Random.Range(-volumeVariance / 2f, volumeVariance / 2f));
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    private void Awake()
    {
        if(instance != null) {
            Debug.LogError("More than one AudioManager in the scene.");
        }
        else {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string _name)
    {
        for(int i = 0;i < sounds.Length;i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        // no sound with that name found
        Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
    }
}
