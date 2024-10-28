using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowPreview : MonoBehaviour
{
    public Button previewBtn; // Assign this in the prefab inspector or get it in Awake
    public string ScreenShotName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Awake()
    {
        if (previewBtn != null)
        {
            previewBtn.onClick.AddListener(ShowPrev);
        }
    }

    public void ShowPrev()
    {
        var path = GameManager.Instance.saveFilePath;
        string verbatimPath = path.Replace("/", "\\"); // Converts forward slashes to backslashes
        var pathString = this.gameObject.GetComponent<ShowPreview>().ScreenShotName;
        // Regex pattern to match the date and time format: 8 digits + underscore + 6 digits
        string pattern = @"(\d{8}_\d{6}(?:_\d+)?)";

        // Replace the matched timestamp with the new timestamp
        string updatedPath = Regex.Replace(path, pattern, pathString);
        GameManager.Instance.saveFilePath = updatedPath;
        string pattern1 = @"\d{8}_\d{6}_\d+\.json";
        if(Regex.IsMatch(updatedPath, pattern1))
        {
            SceneManager.LoadScene("Accessory_Studio_Scene");
        } else
        {
            GameManageraccessories.Instance.isNecLace = false;
            GameManageraccessories.Instance.isRing = false;
            SceneManager.LoadScene("Clothing_Studio_Scene");
        }
    }
}
