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
		for (int i = 0; i < spawnRubbishAmount; i++)
		{
			RaycastHit hit;

			while (true)
			{
				//Gets random x and z coordinate on a plane
				float pointX = Random.Range(spawnPosition1.position.x, spawnPosition2.position.x);
				float pointY = (spawnPosition1.position.y + spawnPosition2.position.y) / 2;
				float pointZ = Random.Range(spawnPosition1.position.z, spawnPosition2.position.z);

				Vector3 spawnPoint = new(pointX, pointY, pointZ);
				
				if (Physics.Raycast(new(spawnPoint, Vector3.down), out hit, 250f, spawnFloorMask))
				{
					// Hits the FloorMask :^)
					Debug.DrawRay(spawnPoint, Vector3.down * 250f, Color.cyan, 16f);
					break;
				} else
				{
					// Didn't hit the FloorMask :^(
					Debug.DrawRay(spawnPoint, Vector3.down * 250f, Color.red, 16f);
				}
			}
			
			// Get random index of rubbish, then spawn at point hit
			int rubbishIndex = Random.Range(1, spawnRubbishGO.Length) - 1;
			Debug.Log("rubbishIndex: " + rubbishIndex);
			Instantiate(spawnRubbishGO[rubbishIndex], hit.point, Quaternion.identity, spawnParent.transform);
		}
	}
}