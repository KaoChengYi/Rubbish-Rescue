using System.Collections.Generic;
using UnityEngine;

public class RubbishManager : MonoBehaviour
{
    public static RubbishManager Instance;

    // Dictionary to keep track of the count of each type of rubbish
    public Dictionary<string, int> collectedRubbishCounts = new Dictionary<string, int>();
    public List<string> correctTags = new List<string>(); // List of tags to look out for

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this game object in all scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add or update the count of collected rubbish tags
    public void AddRubbishTag(string tag)
    {
        if (correctTags.Contains(tag)) // Ensure tag is valid
        {
            if (collectedRubbishCounts.ContainsKey(tag))
            {
                collectedRubbishCounts[tag]++;
            }
            else
            {
                collectedRubbishCounts[tag] = 1;
            }
        }
        else
        {
            Debug.LogWarning($"Tag '{tag}' is not in the list of correct tags.");
        }
    }


    // Clear the rubbish data after using it in the next scene
    public void ClearRubbishData()
    {
        collectedRubbishCounts.Clear();
    }
}
