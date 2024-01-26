using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLauncher : MonoBehaviour
{
    public GameObject app;
    public bool canLaunch = true;
    
    public void LaunchApp()
    {
        if (canLaunch) {
           app.SetActive(app.activeSelf ? false : true);
           if (app.activeSelf) {
               canLaunch = false;
           }
        }
    }
    
    void Update()
    {
        if (!app.activeSelf) {
            canLaunch = true;
        }
    }
}
