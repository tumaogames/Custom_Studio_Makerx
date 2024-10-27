using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpCanvasUIAcc : MonoBehaviour
{
    [SerializeField] private Button goToMainButton;
    [SerializeField] private Button saveItemButton;
    [SerializeField] private Button resetItemButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button backButton;
    [SerializeField] private SaveSceneWithScreenshot SaveManager;

    [SerializeField] private GameObject lockUI;
    [SerializeField] private GameObject garbageUI;
    [SerializeField] private GameObject AccMenuUI;

    private void Start()
    {
        goToMainButton.onClick.AddListener(GoToMainScene);
        saveItemButton.onClick.AddListener(() => SaveItem(this.gameObject));
        resetItemButton.onClick.AddListener(ResetScene);
        exitButton.onClick.AddListener(ExitProgram);
        nextButton.onClick.AddListener(AccNext);
        backButton.onClick.AddListener(AccBack);
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

    public void AccNext()
    {
        garbageUI.SetActive(false);
        AccMenuUI.SetActive(false);
        lockUI.SetActive(true);
        GameManageraccessories.Instance.DisplayAccListDet();
    }

    public void AccBack()
    {
        garbageUI.SetActive(true);
        AccMenuUI.SetActive(true);
        lockUI.SetActive(false);
    }
}
