using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    public ParticleSystem particleSystem; // Reference to the Particle System

    private void OnMouseDown()
    {
        // Play the particle system when the object is clicked
        PlayParticleEffect();
    }

    private void OnMouseUp()
    {
        // Stop the particle system when the mouse button is released
        StopParticleEffect();
    }

    private void PlayParticleEffect()
    {
        if (particleSystem != null)
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
                Debug.Log("Particle system played on drag start.");
            }
        }
        else
        {
            Debug.LogError("Particle system reference is not assigned.");
        }
    }

    private void StopParticleEffect()
    {
        if (particleSystem != null)
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
                Debug.Log("Particle system stopped on drag end.");
            }
        }
    }
}
