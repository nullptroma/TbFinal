using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saves
{
    //Singleton
    private static Saves _instance;
    public static Saves Instance => _instance ??= new Saves();

    private int _nextLevel;
    public int NextLevel
    {
        get => _nextLevel;
        set
        {
            _nextLevel = value;
            Save();
        }
    }
    
    private Saves()
    {
        Load();
    }

    private void Load()
    {
        _nextLevel = PlayerPrefs.GetInt(nameof(NextLevel), 0);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(nameof(NextLevel), NextLevel);
        
        PlayerPrefs.Save();
    }
}
