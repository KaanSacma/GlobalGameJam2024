using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLauncher : MonoBehaviour
{
    public GameObject app;
    public bool canLaunch = true;
    
    private List<AppLauncher> _appLaunchers;
    
    public void LaunchApp()
    {
        if (canLaunch) {
           app.SetActive(app.activeSelf ? false : true);
           if (app.activeSelf) {
               canLaunch = false;
                _appLaunchers.ForEach(appLauncher => appLauncher.canLaunch = false);
           }
        }
    }

    public void LaunchOsApp()
    {
        app.SetActive(app.activeSelf ? false : true);
    }
    
    void Start()
    {
        _appLaunchers = new List<AppLauncher>(FindObjectsOfType<AppLauncher>());
    }
    
    void Update()
    {
        if (!app.activeSelf) {
            canLaunch = true;
            _appLaunchers.ForEach(appLauncher => appLauncher.canLaunch = true);
        }
    }
}
