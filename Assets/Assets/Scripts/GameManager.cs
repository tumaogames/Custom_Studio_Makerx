using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class GameManager : MonoBehaviour
{
    // Static instance of the GameManager
    public static GameManager Instance { get; private set; }
    public GameObject currentDress;

    public event Action<float> priceOnVariableChanged; // Event for variable changes
    public event Action<string> dressNameOnVariableChanged; // Event for variable changes
    public event Action<float> heightOnVariableChanged; // Event for variable changes
    public event Action<float> bustOnVariableChanged; // Event for variable changes
    public event Action<float> hipOnVariableChanged; // Event for variable changes
    public event Action<float> waistOnVariableChanged; // Event for variable changes
    public event Action<ColorEnum> colorOnVariableChanged; // Event for variable changes

    public float _price = 1; // Backing field for the variable
    public float _height = 1; // Backing field for the variable
    public float _bust = 1; // Backing field for the variable
    public float _hip = 1; // Backing field for the variable
    public float _waist = 1; // Backing field for the variable
    public string _dressName = ""; // Backing field for the variable
    public ColorEnum _color = ColorEnum.Red; // Backing field for the variable
    public float price
    {
        get => _price;
        set
        {
            if (_price != value) // Only trigger event if value changes
            {
                _price = value;
                priceOnVariableChanged?.Invoke(_price); // Notify subscribers
            }
        }
    }

    public ColorEnum color
    {
        get => _color;
        set
        {
            if (_color != value) // Only trigger event if value changes
            {
                _color = value;
                colorOnVariableChanged?.Invoke(_color); // Notify subscribers
            }
        }
    }

    public float height
    {
        get => _height;
        set
        {
            if (_height != value) // Only trigger event if value changes
            {
                _height = value;
                priceOnVariableChanged?.Invoke(_height); // Notify subscribers
            }
        }
    }

    public float bust
    {
        get => _bust;
        set
        {
            if (_bust != value) // Only trigger event if value changes
            {
                _bust = value;
                priceOnVariableChanged?.Invoke(_bust); // Notify subscribers
            }
        }
    }

    public string dressName
    {
        get => _dressName;
        set
        {
            if (_dressName != value) // Only trigger event if value changes
            {
                _dressName = value;
                dressNameOnVariableChanged?.Invoke(_dressName); // Notify subscribers
            }
        }
    }

    public float hip
    {
        get => _hip;
        set
        {
            if (_hip != value) // Only trigger event if value changes
            {
                _hip = value;
                hipOnVariableChanged?.Invoke(_hip); // Notify subscribers
            }
        }
    }

    public float waist
    {
        get => _waist;
        set
        {
            if (_waist != value) // Only trigger event if value changes
            {
                _waist = value;
                hipOnVariableChanged?.Invoke(_waist); // Notify subscribers
            }
        }
    }

    public string saveFilePath;

    private void Start()
    {
        saveFilePath = Application.persistentDataPath + "/20241029_042806.json";
    }

    void Update()
    {

    }

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            Instance = this; // Set instance to this
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed when loading new scenes
        }
        else
        {
            Destroy(gameObject); // Destroy this instance if it already exists
        }
    }

    // Load the scene state from the JSON file
    public bool LoadSceneState(string dname)
    {
        bool isAct = false;
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SceneDataWithScreenshot sceneData = JsonUtility.FromJson<SceneDataWithScreenshot>(json);

            // Clear the current scene and instantiate objects from the saved data
            foreach (GameObjectData data in sceneData.objects)
            {
                /*GameObject obj = InstantiatePrefab(data.objectName, data.position, data.rotation);
                if (obj != null)
                {
                    obj.SetActive(data.isActive); // Restore active state
                }*/
                if(data.objectName == dname)
                {
                    isAct = data.isActive;
                    break;
                }
            }

            Debug.Log("Scene state loaded from: " + saveFilePath);
            // Optionally load the screenshot if needed
            // LoadScreenshot(sceneData.screenshotName);
        }
        else
        {
            Debug.LogWarning("No saved scene state found at: " + saveFilePath);
        }
        return isAct;
    }

    public GameObjectDataUI LoadUIState()
    {
        GameObjectDataUI data = null;
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SceneDataWithScreenshot sceneData = JsonUtility.FromJson<SceneDataWithScreenshot>(json);

            // Clear the current scene and instantiate objects from the saved data
            data = sceneData.objectsUI[0];
        }
        return data;
    }

    // Instantiate prefab by name
    private GameObject InstantiatePrefab(string objectName, Vector3 position, Quaternion rotation)
    {
        // Load the prefab from resources (assuming they are located in a Resources folder)
        GameObject prefab = Resources.Load<GameObject>("Dress/" + objectName); // Adjust path as needed
        if (prefab != null)
        {
            GameObject instance = Instantiate(prefab, position, rotation);
            return instance;
        }
        Debug.LogWarning("Prefab not found: " + objectName);
        return null;
    }
}

public enum ColorEnum
{
    Red,
    Blue,
    Green,
    Yellow,
    White,
    Black
}
