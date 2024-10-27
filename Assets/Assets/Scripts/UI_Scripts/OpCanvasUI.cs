using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpCanvasUI : MonoBehaviour
{
    [SerializeField] private Button goToMainButton;
    [SerializeField] private Button saveItemButton;
    [SerializeField] private Button resetItemButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button backButton;
    [SerializeField] private SaveSceneWithScreenshot SaveManager;
    [SerializeField] private GameObject clothesUI;
    [SerializeField] private GameObject radicalUI;
    [SerializeField] private GameObject colorUI;

    private void Start()
    {
        goToMainButton.onClick.AddListener(GoToMainScene);
        saveItemButton.onClick.AddListener(() => SaveItem(this.gameObject));
        resetItemButton.onClick.AddListener(ResetScene);
        exitButton.onClick.AddListener(ExitProgram);
        nextButton.onClick.AddListener(Next);
        backButton.onClick.AddListener(Back);
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void SaveItem(GameObject emptyItemCard)
    {
        // Code to save the item and convert empty_Item_Card to saved_Item_Card
        Debug.Log("save");
        SaveManager.Save();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitProgram()
    {
        Application.Quit();

    }
    public void Next()
    {
        clothesUI.SetActive(false);
        radicalUI.SetActive(false);
        colorUI.SetActive(true);
    }

    public void Back()
    {
        clothesUI.SetActive(true);
        radicalUI.SetActive(true);
        colorUI.SetActive(false);
    }
}
