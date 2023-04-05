using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Blackout blackout;
    private bool _reloading;

    private void Start()
    {
        blackout = FindObjectOfType<Blackout>();
    }

    public void ReloadScene()
    {
        if(_reloading || (blackout!=null && blackout.Started))
            return;
        _reloading = true;
        if (blackout != null)
            blackout.Black(() => Load(SceneManager.GetActiveScene().name));
        else
            Load(SceneManager.GetActiveScene().name);
    }
    
    public void LoadLevel(int id)
    {
        if (blackout != null)
            blackout.Black(() => Load($"Level{id}"));
        else
            Load($"Level{id}");
    }

    public void LoadMenu()
    {
        if(!SceneManager.GetActiveScene().name.Equals("MainMenu"))
            blackout.Black(() => Load("MainMenu"));
    }
    
    private void Load(string sceneName)
    {
        try
        {
            SceneManager.LoadScene(sceneName);
        }
        catch
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
