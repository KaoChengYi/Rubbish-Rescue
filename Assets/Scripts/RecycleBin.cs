using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class RecycleBin : MonoBehaviour, IInteractable
{
	[SerializeField] string sceneName;

    [SerializeField] Slider recycleCenterBar;
	[SerializeField] GameObject[] recycleCenterProgressBarGOs; //Add locks
	[SerializeField] GameObject[] locks;

    public static int recycleCenterProgress = 0;

	private void Start()
	{
		UpdateRecycleBinBar(recycleCenterProgress);
	}


    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.F1)) {
			recycleCenterProgress++;
            UpdateRecycleBinBar(recycleCenterProgress);
        }
    }

    public void Interact()
	{
		// Return if the inventory is not full
		if (!InventoryManager.Instance.IsInventoryFull()) 
			return;

		// Increase Recycling Center Progress by 1
		if (recycleCenterProgress < 3)
		{
			recycleCenterProgress++;
			SceneManager.LoadScene(sceneName);

			return;
		}
	}
	void UpdateRecycleBinBar(int _value)
	{
        recycleCenterProgressBarGOs[_value].SetActive(true);

        for (int i = 0; i < recycleCenterProgressBarGOs.Length; i++)
		{
            if (_value != i)
			{
				recycleCenterProgressBarGOs[i].SetActive(false);
            }
        }
    }
}
