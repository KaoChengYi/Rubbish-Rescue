using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticTransfer : MonoBehaviour
{
	public static float testVar = 1f;

	void Start()
	{

	}



	void GoToNextScene()
	{
		SceneManager.LoadScene("Scene1");
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1)) testVar += 1;
		if (Input.GetKeyDown(KeyCode.Alpha2)) testVar += 2;
		if (Input.GetKeyDown(KeyCode.Alpha3)) testVar += 3;

		if (Input.anyKeyDown) Debug.Log("testVar" + testVar);

		if (Input.GetKeyDown(KeyCode.Space)) GoToNextScene();
	}
}
