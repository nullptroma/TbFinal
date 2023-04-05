using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelController : MonoBehaviour
{
    [SerializeField] private SceneLoader loader;
    [SerializeField] private int nextLevelID;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            loader.LoadLevel(nextLevelID);
        }
    }
}
