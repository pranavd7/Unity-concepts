using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelLoader : MonoBehaviour
{
    private InputSystem_Actions input;
    [SerializeField] private string levelName = "Level2";

    private void Awake()
    {
        input = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        input.UI.Enable();
        input.UI.LoadLevel.performed += OnLoadLevel;
    }

    private void OnDisable()
    {
        input.UI.LoadLevel.performed -= OnLoadLevel;
        input.UI.Disable();
    }

    private void OnLoadLevel(InputAction.CallbackContext ctx)
    {
        GameManager.Instance.LoadLevel(levelName);
    }

    public void LoadLevel(string levelName)
    {
        GameManager.Instance.LoadLevel(levelName);
    }

    private void OnDestroy()
    {
        Debug.Log("LevelLoader destroyed");
    }
}
