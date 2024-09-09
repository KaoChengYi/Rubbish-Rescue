using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ParticleController : MonoBehaviour
{
    [Header("Slider Settings")]
    public Slider slider;
    public float maxRate = 10f; // Maximum rate of particle emission

    [Header("Particle Systems")]
    public ParticleSystem[] particleSystems; // Array of particle systems
    public ParticleSystem additionalParticleSystem; // The particle system to play after slider reaches max

    [Header("UI Settings")]
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

        // Ensure the additional particle system is stopped initially
        if (additionalParticleSystem != null)
        {
            additionalParticleSystem.Stop();
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
            StartCoroutine(PlayAdditionalParticleSystemAfterDelay());
            slider.interactable = false; // Disable slider after it reaches max
        }
    }

    private IEnumerator PlayAdditionalParticleSystemAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds

        // Play the additional particle system
        if (additionalParticleSystem != null)
        {
            additionalParticleSystem.Play();
        }

        // Unhide the button after the particle system starts
        uiButton.gameObject.SetActive(true);
    }
}
