using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class RecycleBin : MonoBehaviour, IInteractable
{
	[SerializeField] string sceneName;

    //[SerializeField] Text recycleCenterText;
    [SerializeField] Slider recycleCenterBar;

	public static int recycleCenterProgressBar = 0;

	private void Start()
	{
		UpdateRecycleBinBar();
	}


	public void Interact()
	{
		// Return if the inventory is not full
		if (!InventoryManager.Instance.IsInventoryFull()) 
			return;

		// Increase Recycling Center Progress by 1
		if (recycleCenterProgressBar < 3) 
			recycleCenterProgressBar++;

		// Load Minigame Scene
		SceneManager.LoadScene(sceneName);
	}
	void UpdateRecycleBinBar()
	{
		recycleCenterBar.value = recycleCenterProgressBar;
	}
}
