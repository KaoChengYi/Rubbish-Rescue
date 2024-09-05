using UnityEngine;
using UnityEngine.UI;

public class ShowUIOnEmpty : MonoBehaviour
{
    // Reference to the UI Button
    public GameObject uiButton; 
    private void Start()
    {
        // Ensure the UI Button is initially hidden
        if (uiButton != null)
        {
            uiButton.SetActive(false);
            Debug.Log("UI Button initially hidden.");
        }
        else
        {
            Debug.LogError("UI Button reference is not assigned.");
        }
    }

    private void Update()
    {
        // Log to confirm Update method is running
        Debug.Log("Update method is running.");

        if (!HasRemainingTrash())
        {
            // Unhide the UI Button
            if (uiButton != null)
            {
                uiButton.SetActive(true);
                Debug.Log("UI Button is now visible.");
            }
            else
            {
                Debug.LogError("UI Button reference is not assigned.");
            }
        }
        else
        {
            Debug.Log("Trash items remaining.");
        }
    }

    // Check if there are remaining trash items with specific tags
    private bool HasRemainingTrash()
    {
        // tags to check
        string[] tags = { "PlasticBottle", "PaperBag", "CoffeeCup", "GlassBottle", "PlasticContainer" };

        foreach (string tag in tags)
        {
            GameObject[] items = GameObject.FindGameObjectsWithTag(tag);
            Debug.Log($"Checking for tag: {tag}, Found count: {items.Length}");

            if (items.Length > 0)
            {
                return true; // There are still items with this tag
            }
        }

        return false; // No items with the specified tags are found
    }
}
