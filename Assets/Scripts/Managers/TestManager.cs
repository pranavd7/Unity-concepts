using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private GameObject spawnPrefab;
    
    public static TestManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log($"Already exists. Destroying this {gameObject.name}");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void TestMethod()
    {
        Debug.Log("TestMethod");
    }
}