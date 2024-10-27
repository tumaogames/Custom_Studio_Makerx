using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavesSceneUI : MonoBehaviour
{
    [SerializeField] private Button emptyItemButton;
    [SerializeField] private Button previewItemButton;
    [SerializeField] private Button deleteItemButton;

    private void Start()
    {
        emptyItemButton.onClick.AddListener(GoToStudioScene);
        //previewItemButton.onClick.AddListener(() => PreviewItem("Clothing_Studio_Scene"));
        //deleteItemButton.onClick.AddListener(() => DeleteItem(this.gameObject));
    }

    public void GoToStudioScene()
    {
        SceneManager.LoadScene("Studio_Scene");
    }

    public void PreviewItem(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void DeleteItem(GameObject savedItemCard)
    {
        Destroy(savedItemCard);
    }
}
