using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishMainSpawner : MonoBehaviour
{
	[SerializeField] int spawnRubbishAmount;

	[SerializeField] Transform spawnParent;

	[SerializeField] GameObject[] spawnRubbishGO;
	[SerializeField] Transform spawnPosition1;
	[SerializeField] Transform spawnPosition2;

	[SerializeField] LayerMask spawnFloorMask;

	private void Start()
	{
		bool hasSpawnedAllType = false;
		int typesSpawned = 0;


		for (int i = 0; i < spawnRubbishAmount; i++)
		{
			RaycastHit hit;
			Vector3 spawnPoint;

			while (true)
			{
				//Gets random x and z coordinate on a plane
				float pointX = Random.Range(spawnPosition1.position.x, spawnPosition2.position.x);
				float pointY = (spawnPosition1.position.y + spawnPosition2.position.y) / 2;
				float pointZ = Random.Range(spawnPosition1.position.z, spawnPosition2.position.z);

				spawnPoint = new(pointX, pointY, pointZ);

				Physics.Raycast(new(spawnPoint, Vector3.down), out hit, 250f);

				int hitLayer = hit.collider.gameObject.layer;

				if ((spawnFloorMask.value & (1 << hitLayer)) != 0)
				{
					// Hits the FloorMask :^)
					break;
				} else
				{
					// Didn't hit the FloorMask :^(
					Debug.DrawRay(spawnPoint, Vector3.down * 250f, Color.red, 16f);
				}
			}

			int rubbishIndex;
			if (!hasSpawnedAllType)
			{
				// Force Spawn the first 3 rubbish from List
				rubbishIndex = typesSpawned;
				typesSpawned++;

				Debug.DrawRay(spawnPoint, Vector3.down * 250f, Color.blue, 16f);

				// Check if the first 3 types of Rubbish are spawned
				if (typesSpawned >= 3) hasSpawnedAllType = true;

			} else
			{
				// Get random index of rubbish instead, then spawn at point hit
				rubbishIndex = Random.Range(0, spawnRubbishGO.Length);

				Debug.DrawRay(spawnPoint, Vector3.down * 250f, Color.cyan, 16f);
			}

			Instantiate(spawnRubbishGO[rubbishIndex], hit.point, Quaternion.identity, spawnParent.transform);
		}
	}
}