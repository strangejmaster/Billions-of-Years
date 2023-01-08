using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Slider sensSlider;
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
    }
    public void saveSetting(string Setting) {
        PlayerPrefs.SetFloat(Setting, sensSlider.value);
        PlayerPrefs.Save();
    }
}
