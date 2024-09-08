using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IbisIan : MonoBehaviour, IInteractable
{
	[SerializeField] float dialogueActiveTime;

	[SerializeField] Text dialogueText;

	[SerializeField] string[] dialogues;
	int dialoguesIndex = 0;

	bool inConversation = false;

	public void Interact()
	{
		if (!inConversation) StartCoroutine(OpenConversation());
	}

	IEnumerator OpenConversation()
	{
		dialogueText.gameObject.SetActive(true);
		dialogueText.text = dialogues[dialoguesIndex];
		inConversation = true;

		yield return new WaitForSeconds(dialogueActiveTime);

		dialogueText.gameObject.SetActive(false);
		dialogueText.text = "";
		inConversation = false;
	}

	public void AdvanceDialogueProgression()
	{
		dialoguesIndex++;
	}
}
