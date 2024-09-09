using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button[] buttons; // Array to hold multiple buttons
    [SerializeField] private string[] sceneNames; // Array to hold scene names for each button

    private static bool[] buttonsPressed; // Static array to track button states

    private void Awake()
    {
        // Initialize the static array if needed
        if (buttonsPressed == null || buttonsPressed.Length != buttons.Length)
        {
            buttonsPressed = new bool[buttons.Length];
        }

        DontDestroyOnLoad(gameObject); // Preserve this object across scenes

        // Check if the number of buttons matches the number of scene names
        if (buttons.Length != sceneNames.Length)
        {
            Debug.LogError("Mismatch between buttons and sceneNames array length.");
            return;
        }

        // Initialize button states and subscribe to click events
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] != null)
            {
                buttons[i].interactable = !buttonsPressed[i];
                int index = i; // Capture the index for the listener
                buttons[i].onClick.AddListener(() => OnButtonClick(index));
            }
            else
            {
                Debug.LogError($"Button at index {i} is not assigned.");
            }
        }
    }

    private void OnButtonClick(int index)
    {
        // Disable the button
        if (index >= 0 && index < buttons.Length)
        {
            buttons[index].interactable = false;
            buttonsPressed[index] = true; // Update button state

            // Load the scene associated with the button
            string sceneName = sceneNames[index];
            SceneManager.LoadScene(sceneName);
        }
    }
}
