using System.Collections.Generic;
using UnityEngine;

public class RubbishSpawner : MonoBehaviour
{
    public GameObject plasticBottlePrefab;
    public GameObject glassBottlePrefab;
    public GameObject plasticContainerPrefab;
    public GameObject coffeeCupPrefab;
    public GameObject paperBagPrefab;
    public GameObject bananaPrefab;
    public GameObject fishBonePrefab;

    // Parameters for spawn area
    public Vector3 spawnAreaCenter = new Vector3(0, 0, 0);
    public Vector3 spawnAreaSize = new Vector3(10, 10, 10);

    private void Start()
    {
        SpawnCollectedRubbish();
    }

    private void SpawnCollectedRubbish()
    {
        if (RubbishManager.Instance != null)
        {
            Debug.Log("RubbishManager.Instance is not null.");
            foreach (var item in RubbishManager.Instance.collectedRubbishCounts)
            {
                GameObject prefab = GetPrefabForTag(item.Key);
                if (prefab != null)
                {
                    Debug.Log($"Spawning {item.Value} items with tag {item.Key}");
                    for (int i = 0; i < item.Value; i++)
                    {
                        Instantiate(prefab, GetRandomSpawnPosition(), Quaternion.identity);
                    }
                }
                else
                {
                    Debug.LogWarning($"Prefab for tag '{item.Key}' is not assigned.");
                }
            }
        }
        else
        {
            Debug.LogError("RubbishManager.Instance is null.");
        }
    }

    private GameObject GetPrefabForTag(string tag)
    {
        switch (tag)
        {
            case "PlasticBottle":
                return plasticBottlePrefab;
            case "GlassBottle":
                return glassBottlePrefab;
            case "PlasticContainer":
                return plasticContainerPrefab;
            case "CoffeeCup":
                return coffeeCupPrefab;
            case "PaperBag":
                return paperBagPrefab;
            case "Banana":
                return bananaPrefab;
            case "FishBone":
                return fishBonePrefab;
            default:
                Debug.LogWarning($"No prefab assigned for tag: {tag}");
                return null;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float halfWidth = spawnAreaSize.x / 2;
        float halfHeight = spawnAreaSize.y / 2;
        float halfDepth = spawnAreaSize.z / 2;

        float x = Random.Range(spawnAreaCenter.x - halfWidth, spawnAreaCenter.x + halfWidth);
        float y = Random.Range(spawnAreaCenter.y - halfHeight, spawnAreaCenter.y + halfHeight);
        float z = Random.Range(spawnAreaCenter.z - halfDepth, spawnAreaCenter.z + halfDepth);

        return new Vector3(x, y, z);
    }
}
