using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseInteract : MonoBehaviour
{
    [SerializeField] float interactRange;
    [SerializeField] Camera playerCamera;

    int minigamesCompleted = 0;

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

        //Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactRange, Color.red);

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();

            interactable?.Interact();
        }
    }
}