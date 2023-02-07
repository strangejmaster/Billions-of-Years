using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class loadScene : MonoBehaviour
{   
    public GameObject[] displayPages;

    public void Start() {
        displayPages[0].SetActive(false);
        string lastActive = PlayerPrefs.GetString("previousScene", "MainMenu");
        displayPages[0].SetActive(true); //Set MainMenu active incase nothing is found.
        for (int i = 0; i < 7; i++) {
            if (displayPages[i].name == lastActive) {
                displayPages[0].SetActive(false); //Turn off MainMenu default
                displayPages[i].SetActive(true);
                break;
            }
        }
    }

    public void loadSceneByName() {
        PlayerPrefs.SetString("previousScene", EventSystem.current.currentSelectedGameObject.transform.parent.parent.name);

        string sceneName = EventSystem.current.currentSelectedGameObject.name;
        sceneName = sceneName.ToLower();
        SceneManager.LoadScene("Scenes/Events/" + sceneName + "/" + sceneName);
    }
    public void loadMainMenu() {
        SceneManager.LoadScene("Scenes/Menu");
    }
}