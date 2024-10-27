using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotLoader : MonoBehaviour
{
    public GameObject imagePrefab; // Assign your prefab with an Image component in the Inspector
    public Transform contentParent; // Assign the parent transform where instantiated images will be placed

    void Start()
    {
        List<string> jpgScreenshots = FindJpgScreenshots();

        foreach (string path in jpgScreenshots)
        {
            LoadAndInstantiateImage(path);
        }
    }

    List<string> FindJpgScreenshots()
    {
        List<string> jpgFiles = new List<string>();
        string[] files = Directory.GetFiles(Application.persistentDataPath, "*.png", SearchOption.AllDirectories);
        jpgFiles.AddRange(files);
        return jpgFiles;
    }

    void LoadAndInstantiateImage(string filePath)
    {
        // Load the image as a Texture2D
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);

        // Convert the Texture2D to a Sprite
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

        // Instantiate the prefab and set its image
        GameObject imageInstance = Instantiate(imagePrefab, contentParent);
        Image imageComponent = imageInstance.GetComponent<Image>();

        if (imageComponent != null)
        {
            imageComponent.sprite = sprite;
        }
    }
}

