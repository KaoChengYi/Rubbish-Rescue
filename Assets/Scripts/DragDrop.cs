using UnityEngine;

public class DragDrop : MonoBehaviour
{
    // Make _startPosition public to be accessible by TrashSorting
    public Vector3 _startPosition { get; private set; }

    // Flag to check if the object is being dragged
    public bool isDragging { get; set; }


    private void Start()
    {
        // Initialize the start position when the object is first created
        _startPosition = transform.position;
    }

    private void OnMouseDown()
    {
        // Update the start position every time the drag starts
        _startPosition = transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Convert the mouse position to world position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Ensure the z-position remains consistent
            transform.position = mousePosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
