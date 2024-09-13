using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RubbishPickup : MonoBehaviour, IInteractable
{
    [SerializeField] Rubbish rubbish;

    // the audio manager for rubbish sounds
    //public string pickupSoundName;
    private AudioManager audioManager;

    void Start() {
        // cache audio manager
        audioManager = AudioManager.instance;
        if (audioManager == null) {
            Debug.LogError("No AudioManager found in the scene.");
            return;
        }
    }

    public void Interact()
    {
		// Don't do anything if the inventory is full
		if (InventoryManager.Instance.IsInventoryFull()) return;

        InventoryManager.Instance.AddItem(rubbish);

        // play sound on pickup TODO custom sound per rubbish item
        //audioManager.PlaySound(pickupSoundName);
        audioManager.PlaySound("pickupPlastic");

        //Debug.LogWarning("AudioManager: sound attempted to play " + pickupSoundName);

        Destroy(gameObject);
    }
}
