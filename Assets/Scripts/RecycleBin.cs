using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class RecycleBin : MonoBehaviour, IInteractable
{
	[SerializeField] string sceneName;

	[SerializeField] GameObject[] recycleCenterProgressBarGOs;
	[SerializeField] GameObject[] locksGO;

	[SerializeField] GameObject openGO;
	[SerializeField] GameObject closeGO;
	[SerializeField] GameObject plankGO;
	[SerializeField] GameObject brightCube;
	[SerializeField] BoxCollider doorBoxCollider;
	[SerializeField] Animator doorAnimator;

    public static int recycleCenterProgress = 0;

	private void Start()
	{
		UpdateEnvironmentGO(recycleCenterProgress);
	}


    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.F1)) {
			recycleCenterProgress++;
            UpdateEnvironmentGO(recycleCenterProgress);
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
	void UpdateEnvironmentGO(int _value)
	{
        recycleCenterProgressBarGOs[_value].SetActive(true);

        for (int i = 0; i < 3; i++)
		{
            if (_value != i)
			{
				recycleCenterProgressBarGOs[i].SetActive(false);
            }
		}

		switch (_value)
		{
			case 1:
				locksGO[0].SetActive(false);
				break;
			case 2:
				locksGO[0].SetActive(false);
				locksGO[1].SetActive(false);
				break; 
			case 3:
				brightCube.SetActive(true);

				locksGO[0].SetActive(false);
				locksGO[1].SetActive(false);
				locksGO[2].SetActive(false);

				openGO.SetActive(true);
				plankGO.SetActive(false);

				closeGO.SetActive(false);

				doorBoxCollider.enabled = false;

				doorAnimator.enabled = true;
				break; 
			default:
				break;
		}
    }
}
