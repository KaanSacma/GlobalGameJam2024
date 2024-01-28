using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginToOs : MonoBehaviour
{
    public string sceneOs;
    public TextMeshProUGUI textInput;
    public TextMeshProUGUI hintText;
    public int numberOfErrors = 2;
    private int _errors = 0;
    
    public void Login()
    {
        if (textInput.text.Substring(0, textInput.text.Length - 1).Equals("Password")) {
            SceneManager.LoadScene(sceneOs, LoadSceneMode.Single);
            _errors = 0;
        } else {
            _errors++;
            if (_errors >= numberOfErrors) {
                hintText.text = "Hint: The Password is Password";
            }
        }
    }
}
