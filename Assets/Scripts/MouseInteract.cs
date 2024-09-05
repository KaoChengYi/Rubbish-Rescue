using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseInteract : MonoBehaviour
{
    [SerializeField] float interactRange;
    [SerializeField] string sceneNameToLoad;
    [SerializeField] Camera playerCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.E)) Interact();
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactRange, Color.green);
	}

	private void Interact()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactRange, Color.red);

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            if (!InventoryManager.Instance.IsInventoryFull())
            {
                IInteractable interactable = hit.transform.GetComponent<IInteractable>();

                interactable?.Interact();
            }

            if (hit.transform.CompareTag("SceneChangeTrigger"))
            {
                ChangeScene(); // Call the method to change scene
            }
        }
    }


    // Method to load the new scene
    private void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneNameToLoad))
        {
            SceneManager.LoadScene(sceneNameToLoad);
            Debug.Log("Scene changed to: " + sceneNameToLoad);
        }
        else
        {
            Debug.LogError("Scene name is not specified.");
        }
    }
}