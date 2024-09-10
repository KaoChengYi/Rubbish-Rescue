using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorBeltController : MonoBehaviour
{
    [Header("Slider Settings")]
    public Slider slider;
    public float maxRate = 10f; // Maximum rate of particle emission

    [Header("Particle Systems")]
    public ParticleSystem[] particleSystems; // Array of particle systems

    [Header("Conveyor Belt Settings")]
    public GameObject[] objectsToMove; // The 3 objects to move on the conveyor
    public float moveSpeed = 2f; // Speed at which the objects move
    public float moveDistance = 10f; // How far the objects move
    public Button uiButton; // UI button to unhide after the sequence

    private void Start()
    {
        // Listen for slider value changes
        slider.onValueChanged.AddListener(OnSliderValueChanged);

        // Initially hide the button
        uiButton.gameObject.SetActive(false);

        // Ensure all particle systems are stopped initially
        foreach (ParticleSystem ps in particleSystems)
        {
            ps.Stop();
        }
    }

    private void OnSliderValueChanged(float value)
    {
        // Adjust the particle emission rate based on the slider value
        foreach (ParticleSystem ps in particleSystems)
        {
            var emission = ps.emission;
            emission.rateOverTime = value * maxRate; // Adjust particle rate

            // Play particle system if it's not already playing
            if (!ps.isPlaying)
            {
                ps.Play();
            }
        }

        // Check if the slider is at its max value
        if (Mathf.Approximately(value, slider.maxValue))
        {
            StartCoroutine(StartConveyorAfterDelay());
            slider.interactable = false; // Disable slider after it reaches max
        }
    }

    private IEnumerator StartConveyorAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        StartCoroutine(MoveObjectsOneByOne()); // Start moving the objects
    }

    private IEnumerator MoveObjectsOneByOne()
    {
        foreach (GameObject obj in objectsToMove)
        {
            Vector3 startPosition = obj.transform.position;
            Vector3 endPosition = startPosition + Vector3.right * moveDistance;

            // Move the object to the right
            while (Vector3.Distance(obj.transform.position, endPosition) > 0.1f)
            {
                obj.transform.position = Vector3.MoveTowards(obj.transform.position, endPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            obj.transform.position = endPosition;

            yield return new WaitForSeconds(0.1f);
        }

        // Unhide the button after all objects are moved
        uiButton.gameObject.SetActive(true);
    }
}
