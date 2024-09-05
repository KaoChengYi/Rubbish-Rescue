using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public Vector3 _startPosition { get; private set; }
    public bool isDragging { get; private set; } // Encapsulate setting this property to within the class
    private Collider2D _collider;

    private void Start()
    {
        // Initialize the start position when the object is first created
        _startPosition = transform.position;

        // Get the Collider2D component to ensure it's present
        _collider = GetComponent<Collider2D>();
        if (_collider == null)
        {
            Debug.LogError("No Collider2D component found on " + gameObject.name);
        }
    }

    private void OnMouseDown()
    {
        if (_collider != null)
        {
            // Update the start position every time the drag starts
            _startPosition = transform.position;
            isDragging = true;
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Convert the mouse position to world position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z; // Keep the object's original z-position
            transform.position = mousePosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
