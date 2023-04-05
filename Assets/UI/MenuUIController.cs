using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private SceneLoader loader;
    
    void Start()
    {
        //playBtn.onClick.AddListener(()=>loader.LoadLevel(Saves.Instance.NextLevel));
        playBtn.onClick.AddListener(()=>loader.ReloadScene());
    }
}
