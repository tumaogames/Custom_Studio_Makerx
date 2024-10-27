using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnStartButtonClick()
    {
        Debug.Log("Start Button Clicked");  // Check if this gets logged
        SceneManager.LoadScene("Saves_Scene");
    }

    private void OnExitButtonClick()
    {
        Debug.Log("Exit Button Clicked");  // Check if this gets logged
        Application.Quit();
    }
}

