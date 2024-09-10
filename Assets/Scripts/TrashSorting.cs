using UnityEngine;
using UnityEngine.UI; // Include this for UI components
using System.Collections;
using System.Collections.Generic;

public class TrashSorting : MonoBehaviour
{
    // Duration for the flicker effect
    public float flickerDuration = 0.5f;

    // List of correct tags for this bin
    public List<string> correctTags = new List<string>();

    // Original color of the bin
    private Color _originalColor;
    private SpriteRenderer _binRenderer;

    private void Start()
    {
        // Get the SpriteRenderer component to change bin color
        _binRenderer = GetComponent<SpriteRenderer>();
        if (_binRenderer != null)
        {
            _originalColor = _binRenderer.color;
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found on " + gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the bin is a trash item
        if (other.CompareTag("PlasticBottle") || other.CompareTag("FishBone") || other.CompareTag("Banana") || other.CompareTag("PlasticContainer") || other.CompareTag("PaperBag") || other.CompareTag("CoffeeCup") || other.CompareTag("GlassBottle"))
        {

        // Check if the trash tag matches any of the correct tags set in the Inspector
        if (correctTags.Contains(other.tag))
            {
                // Correct bin: Destroy the trash object
                Destroy(other.gameObject);
                Debug.Log("Correct bin!");
            }
            else
            {
                // Incorrect bin: Reset position and flicker bin color
                StartCoroutine(HandleIncorrectTrash(other));
                Debug.Log("Incorrect bin!");
            }
        }
    }

    // Coroutine to handle incorrect trash
    private IEnumerator HandleIncorrectTrash(Collider2D trash)
    {
        // Flicker bin color
        StartCoroutine(FlickerBinColor());

        // Wait for flicker effect to complete
        yield return new WaitForSeconds(flickerDuration);

        // Check if the trash object is still valid
        if (trash != null)
        {
            // Reset trash position regardless of dragging state
            DragDrop dragDrop = trash.GetComponent<DragDrop>();
            if (dragDrop != null)
            {
                trash.transform.position = dragDrop._startPosition;
                Debug.Log("Resetting position to: " + dragDrop._startPosition);
            }
            else
            {
                Debug.LogWarning("DragDrop component not found on trash.");
            }
        }
        else
        {
            Debug.LogWarning("Trash object has been destroyed, cannot reset position.");
        }
    }

    private IEnumerator FlickerBinColor()
    {
        if (_binRenderer != null)
        {
            _binRenderer.color = Color.black;
            yield return new WaitForSeconds(flickerDuration); // Wait for the flicker duration
            _binRenderer.color = _originalColor; // Reset bin color to original
        }
        else
        {
            Debug.LogError("SpriteRenderer not found, cannot flicker color.");
        }
    }
}
