using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveSceneWithScreenshot : MonoBehaviour
{
    // List to hold data of all game objects that you want to save
    public List<GameObjectData> sceneObjectsData = new List<GameObjectData>();
    public List<GameObjectDataUI> sceneObjectsDataUI = new List<GameObjectDataUI>();
    private string saveFilePath;
    public DressManager dm;
    // URL to send the request to
    private string url = "https://zappnott.shop/api/data";
    public string jsonData = null;

    void Update()
    {
    }

    private void Start()
    {
        
    }

    public void Send()
    {
        Debug.Log("Send");
        StartCoroutine(SendRequest(jsonData));
    }

    public void Save()
    {
        string screenshotName = CaptureScreenshot(); // Capture the screenshot and get its name
        SaveSceneState(screenshotName); // Save the scene state with the screenshot name
    }

    // Save the state of objects in the scene, including the screenshot name
    public void SaveSceneState(string screenshotName)
    {
        sceneObjectsData.Clear();
        sceneObjectsDataUI.Clear();

        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag("Saveable"))
            {
                GameObjectData data = new GameObjectData
                {
                    objectName = obj.name,
                    position = obj.transform.position,
                    rotation = obj.transform.rotation,
                    isActive = obj.activeSelf, // Save active state
                    isPrefab = IsPrefab(obj) // Save whether the object is a prefab
                };
                sceneObjectsData.Add(data);
                Debug.Log("GameObject Name: " + obj.name + ", Position: " + obj.transform.position);
            }

            if (obj.CompareTag("SaveableUI"))
            {
                LogDescendantNames(obj.transform);
                
                //Debug.Log("GameObject Name: " + obj.name + ", Position: " + obj.transform.position);*/
            }
        }

        // Include the screenshot name in the serialized data
        SceneDataWithScreenshot sceneData = new SceneDataWithScreenshot
        {
            objects = sceneObjectsData,
            objectsUI = sceneObjectsDataUI,
            screenshotName = screenshotName
        };

        string json = JsonUtility.ToJson(sceneData, true);
        jsonData = json;
        File.WriteAllText(saveFilePath, json);

        Debug.Log("Scene state saved to: " + saveFilePath);
    }

    void LogDescendantNames(Transform parent)
    {
        Color dcolor = Color.black;
        float dprice = 0;
        string dname = null;
        float dheight = 0;
        float dbust = 0;
        float dhip = 0;
        float dwaist = 0;
        foreach (Transform child in parent)
        {

            Debug.Log("Descendant Name: " + child.gameObject.name);
            switch (child.gameObject.name)
            {
                case "DressName":
                    dname = child.gameObject.GetComponent<TextMeshProUGUI>().text;
                    break;
                case "Slider_Height":
                    dheight = child.gameObject.GetComponent<Slider>().value;
                    break;
                case "Slider_Bust":
                    dbust = child.gameObject.GetComponent<Slider>().value;
                    break;
                case "Slider_Hips":
                    dhip = child.gameObject.GetComponent<Slider>().value;
                    break;
                case "Slider_Waist":
                    dwaist = child.gameObject.GetComponent<Slider>().value;
                    break;
                default:
                    break;
            }
            
        }

        GameObjectDataUI data = new GameObjectDataUI
        {
            color = dcolor,
            price = dprice,
            dressName = dname,
            height = dheight,
            bust = dbust, // Save active state
            hip = dhip,
            waist = dwaist // Save whether the object is a prefab
        };
        sceneObjectsDataUI.Add(data);
            
    }

    // Check if the GameObject is a prefab
    private bool IsPrefab(GameObject obj)
    {
        // Check if the object is part of a prefab instance
        if (PrefabUtility.IsPartOfPrefabInstance(obj))
        {
            Debug.Log($"{obj.name} is a prefab instance.");
            return true; // It's a prefab instance
        }

        // Check if the object is a prefab asset
        PrefabAssetType assetType = PrefabUtility.GetPrefabAssetType(obj);

        if (assetType != PrefabAssetType.NotAPrefab)
        {
            Debug.Log($"{obj.name} is a prefab asset of type: {assetType}");
            return true; // It's a prefab asset
        }

        Debug.Log($"{obj.name} is not a prefab.");
        return false; // Not a prefab
    }


    // Capture and save a screenshot, returning the screenshot file name
    public string CaptureScreenshot()
    {
        var tName = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        saveFilePath = Application.persistentDataPath + "/" + tName + ".json";
        // Define the file name and path for the screenshot
        string screenshotName = "screenshot_" + tName + ".png";
        string screenshotPath = Application.persistentDataPath + "/" + screenshotName;

        // Take the screenshot and save it to the specified path
        ScreenCapture.CaptureScreenshot(screenshotPath);

        Debug.Log("Screenshot saved to: " + screenshotPath);
        return screenshotName; // Return the screenshot name for saving with the scene data
    }

    // Coroutine to send the web request
    IEnumerator SendRequest(string json)
    {
        // Create a new UnityWebRequest with the URL and the JSON data
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            // Convert the JSON string to a byte array
            byte[] jsonToSend = new UTF8Encoding().GetBytes(json);

            // Set the request body
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);

            // Set the response handler
            request.downloadHandler = new DownloadHandlerBuffer();

            // Set the content type to JSON
            request.SetRequestHeader("Content-Type", "application/json");

            // Send the request and wait for a response
            yield return request.SendWebRequest();

            // Check for errors
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                // Success! Handle the response if needed
                Debug.Log("Response: " + request.downloadHandler.text);
            }
        }
    }


}

// Serializable class to hold data about scene objects
[System.Serializable]
public class GameObjectData
{
    public string objectName;
    public Vector3 position;
    public Quaternion rotation;
    public bool isActive; // To save whether the object is active or not
    public bool isPrefab; // To save whether the object is a prefab
}

// Serializable class to hold data about scene objects
[System.Serializable]
public class GameObjectDataUI
{
    public Color color;
    public float price;
    public string dressName;
    public float height;
    public float bust;
    public float hip;
    public float waist;
}

// Class to hold the scene data including the screenshot name
[System.Serializable]
public class SceneDataWithScreenshot
{
    public List<GameObjectData> objects; // List of game object data
    public List<GameObjectDataUI> objectsUI; // List of game object data
    public string screenshotName; // The name of the saved screenshot
}

// Wrapper for serializing lists (optional, now integrated into SceneDataWithScreenshot)
[System.Serializable]
public class SerializationWrapper<T>
{
    public List<T> items;

    public SerializationWrapper(List<T> items)
    {
        this.items = items;
    }
}
