using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pausedMenuGO;

    //[SerializeField] TMP_Text sensitivityText; // Removed at the moment
    //[SerializeField] Slider sensitivitySlider; // Removed at the moment

	[SerializeField] FirstPersonMovement firstPersonMovement;
    [SerializeField] FirstPersonLook firstPersonLook;
    // Name of credits scene
    [SerializeField] string creditsSceneName;
    public float waitTime;
    public Animator musicAnim;
    public Animator transitionAnim;

    private bool isPaused = false;

	private void Start()
	{
        pausedMenuGO.SetActive(false);
	}

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) Pause();
            else Resume();
        }
    }


    public void Credits()
    {
        // Load the scene specified in the creditsSceneName variable
        Time.timeScale = 1f;
        isPaused = false;
        StartCoroutine(ChangeScene());
    }

    public void Pause()
    {
        pausedMenuGO.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        firstPersonMovement.enabled = false;
        firstPersonLook.enabled = false;

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pausedMenuGO.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        firstPersonMovement.enabled = true;
        firstPersonLook.enabled = true;

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Introduction");
    }

    IEnumerator ChangeScene()
    {
        musicAnim.SetTrigger("FadeOut");
        transitionAnim.SetTrigger("SceneFadeOut");
        SoundManager.PlaySound(SoundType.UIPLAY);
        yield return new WaitForSeconds(waitTime);
        // Load the scene specified in the sceneName variable
        SceneManager.LoadScene(creditsSceneName);
    }

    //public void OnSensitivityChange() // 10 to 25 // Removed at the moment
    //{
    //       float newSensitivity = sensitivitySlider.value / 10f;

    //	firstPersonLook.sensitivity = newSensitivity;
    //       sensitivityText.text = newSensitivity.ToString("F1");
    //   }
}