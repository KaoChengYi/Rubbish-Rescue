using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishPickup : MonoBehaviour, IInteractable
{
	[SerializeField] Rubbish rubbish;

	public void Interact()
	{
		InventoryManager.Instance.AddItem(rubbish);

		Destroy(gameObject);
	}
}
