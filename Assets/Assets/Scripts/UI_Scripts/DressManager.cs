using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;
using Unity.VisualScripting;
using System.IO;

public class DressManager : MonoBehaviour
{
    public TMP_Text dnameText;
    public Slider heightText;
    public Slider bustText;
    public Slider hipsText;
    public Slider waistText;
    public ClothesUIManager clothUI;
    
    public GameObject[] dress = new GameObject[3];
    public GameObject[] dressDetails = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        // Add listener for value changes on the slider
        heightText.onValueChanged.AddListener(OnSliderValueChanged1);
        bustText.onValueChanged.AddListener(OnSliderValueChanged2);
        hipsText.onValueChanged.AddListener(OnSliderValueChanged3);
        waistText.onValueChanged.AddListener(OnSliderValueChanged4);
    }

    private void Update()
    {
        //Optionally, initialize the slider with the current value from GameManager
        heightText.value = GameManager.Instance.height;
        bustText.value = GameManager.Instance.bust;
        hipsText.value = GameManager.Instance.hip;
        waistText.value = GameManager.Instance.waist;
        dnameText.text = GameManager.Instance.dressName;
    }

    // Method signature must match UnityAction<float>
    void OnSliderValueChanged1(float value)
    {
        // Save the slider's value to the GameManager's waistValue variable
        GameManager.Instance.height = value;
        clothUI.UpdateText();
    }
    // Method signature must match UnityAction<float>
    void OnSliderValueChanged2(float value)
    {
        // Save the slider's value to the GameManager's waistValue variable
        GameManager.Instance.bust = value;
        clothUI.UpdateText();
    }
    // Method signature must match UnityAction<float>
    void OnSliderValueChanged3(float value)
    {
        // Save the slider's value to the GameManager's waistValue variable
        GameManager.Instance.hip = value;
        clothUI.UpdateText();
    }
    // Method signature must match UnityAction<float>
    void OnSliderValueChanged4(float value)
    {
        // Save the slider's value to the GameManager's waistValue variable
        GameManager.Instance.waist = value;
        clothUI.UpdateText();
    }

    // Method signature must match UnityAction<float>
    void OnSliderValueChanged5(string value)
    {
        // Save the slider's value to the GameManager's waistValue variable
        GameManager.Instance.dressName = value;
        clothUI.UpdateText();
    }

    private void OnEnable()
    {
        if (IsFolderNotEmpty(Application.persistentDataPath))
        {
            foreach (var dres in dress)
            {
                dres.gameObject.SetActive(GameManager.Instance.LoadSceneState(dres.gameObject.name));
                if (GameManager.Instance.LoadSceneState(dres.gameObject.name))
                    GameManager.Instance.currentDress = dres;
            }

            foreach (var dresDet in dressDetails)
            {
                Debug.Log(GameManager.Instance.LoadUIState().height);
                switch (dresDet.gameObject.name)
                {
                    case "DressName":
                        GameManager.Instance.dressName = GameManager.Instance.LoadUIState().dressName;
                        //GameManager.Instance.dressName = GameManager.Instance.LoadUIState().dressName;
                        break;
                    case "Slider_Height":
                        GameManager.Instance.height = GameManager.Instance.LoadUIState().height;
                        break;
                    case "Slider_Bust":
                        GameManager.Instance.bust = GameManager.Instance.LoadUIState().bust;
                        break;
                    case "Slider_Hips":
                        GameManager.Instance.hip = GameManager.Instance.LoadUIState().hip;
                        break;
                    case "Slider_Waist":
                        GameManager.Instance.waist = GameManager.Instance.LoadUIState().waist;
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
    private bool IsFolderNotEmpty(string path)
    {
        // Check if the folder exists
        if (Directory.Exists(path))
        {
            // Get all files in the directory
            string[] files = Directory.GetFiles(path);
            // Get all subdirectories in the directory
            string[] directories = Directory.GetDirectories(path);

            // Return true if there are any files or directories
            return files.Length > 0 || directories.Length > 0;
        }

        // Return false if the directory does not exist
        return false;
    }
}
