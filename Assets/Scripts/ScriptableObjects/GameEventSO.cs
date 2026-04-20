using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObjects/GameEventSO", order = 2)]
public class GameEventSO : ScriptableObject
{
    private readonly List<System.Action> listeners = new List<System.Action>();

    public void Raise()
    {
        foreach (var listener in listeners)
            listener.Invoke();
    }

    public void Register(System.Action listener) => listeners.Add(listener);
    public void Unregister(System.Action listener) => listeners.Remove(listener);
}
