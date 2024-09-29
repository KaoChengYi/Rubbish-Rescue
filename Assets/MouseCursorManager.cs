using UnityEngine;

public class MouseCursorManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false; // Hide the cursor
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }
}
