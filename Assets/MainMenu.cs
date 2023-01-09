using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Slider sensSlider;
    public Toggle toggle;
    private void Start() {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        loadSettings();
    }
    public void close() {
        Application.Quit();
    }
    public void LoadScene(string Scene) {
        SceneManager.LoadScene(Scene);
    }
    private void loadSettings() {
        sensSlider.value = PlayerPrefs.GetFloat("sensitivity");
        toggle.isOn = (PlayerPrefs.GetInt("isFullScreen")) == 1 ? true : false;
        checkFullScreen();
    }
    public void saveSettings() {
        PlayerPrefs.SetFloat("sensitivity", sensSlider.value);
        PlayerPrefs.SetInt("isFullScreen", toggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
        checkFullScreen();
    }
    public void toggleActive(GameObject Obj) {
        Obj.SetActive(!Obj.activeInHierarchy);
    }
    private void checkFullScreen() {
        if ((PlayerPrefs.GetInt("isFullScreen")) == 1 ? true : false) {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        } else {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}
