using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NPCSpawner: MonoBehaviour
{
    [SerializeField] private List<NpcDataSO> npcDataSOs;

    private void Start()
    {
        foreach (NpcDataSO npcData in npcDataSOs)
        {
            SpawnNPC(npcData);
        }
    }

    private void SpawnNPC(NpcDataSO npcData)
    {
        // Instantiate with spawn position.
        GameObject npc = Instantiate(npcData.prefab, npcData.spawnPosition, Quaternion.identity);

        // Init with data.
        
    }
}