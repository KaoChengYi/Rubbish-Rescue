using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishPickup : MonoBehaviour, IInteractable
{
    [SerializeField] Rubbish rubbish;

    public void Interact()
    {
		// Don't do anything if the inventory is full
		if (InventoryManager.Instance.IsInventoryFull()) return;

        InventoryManager.Instance.AddItem(rubbish);
        Destroy(gameObject);
    }
}
