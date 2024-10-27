using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StudioSceneUI : MonoBehaviour
{
    [SerializeField] private Button goToClothesButton;
    [SerializeField] private Button goToAccButton;
    [SerializeField] private Button backToSavesButton;

    private void Start()
    {
        goToClothesButton.onClick.AddListener(GoToClothesScene);
        goToAccButton.onClick.AddListener(GoToAccessoryScene);
        backToSavesButton.onClick.AddListener(BackToSavesScene);
    }

    public void GoToClothesScene()
    {
        SceneManager.LoadScene("Clothing_Studio_Scene");
    }

    public void GoToAccessoryScene()
    {
        SceneManager.LoadScene("Accessory_Studio_Scene");
    }

    public void BackToSavesScene()
    {
        SceneManager.LoadScene("Saves_Scene");
    }
}

