using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.IO;
using System.Linq;

using TMPro;

public class getDescription : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    void Start() {
        string sceneName = SceneManager.GetActiveScene().name;
        string eventCount = sceneName.Remove(0,5);
        
        string filePathRead = Application.streamingAssetsPath + "/events.txt";
        List<string> filesLines = File.ReadAllLines(filePathRead).ToList();
        int lineI = 0;
        foreach (string line in filesLines) {
            if (line.Contains(eventCount + " Description:")) {
                title.text = "Event " + filesLines[lineI-2];
                description.text = line.Remove(0, eventCount.Length + 14 /*Amount of characters in " Description: "*/);
                break;
            }
            lineI++;
        }
    }
}
