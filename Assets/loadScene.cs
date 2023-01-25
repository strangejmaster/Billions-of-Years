using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public void loadSceneByName() {
        string sceneName = EventSystem.current.currentSelectedGameObject.name;
        sceneName = sceneName.ToLower();
        SceneManager.LoadScene("Scenes/Events/" + sceneName + "/" + sceneName);
    }
    public void loadMainMenu() {
        SceneManager.LoadScene("Scenes/Menu");
    }
}