using UnityEngine;

[CreateAssetMenu(fileName = "NPCDataSO", menuName = "ScriptableObjects/NPCDataSO", order = 1)]
public class NpcDataSO : ScriptableObject
{
    public GameObject prefab;
    public string name;
    public float health = 100;
    public bool isInteractable;
    public Vector3 spawnPosition;
}