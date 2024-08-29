using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        // Check if the particle collision came from a particle system
        if (other.GetComponent<ParticleSystem>() != null)
        {
            Debug.Log("Particle collision detected with: " + gameObject.name);
            Destroy(gameObject); // Destroy the GameObject this script is attached to
        }
    }
}
