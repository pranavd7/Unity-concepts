using System;

public class GameEvents
{
    public delegate bool BoolDelegate(int value);
    public delegate int IntDelegate(int value);
    public delegate float FloatDelegate(float value);
    
    public static event BoolDelegate OnPlayerInitialized;
    public static event BoolDelegate OnPlayerDeath;
    public static event BoolDelegate OnPlayerKilled;
    public static event BoolDelegate OnUiUpdated;
    
    public static event Action<int> OnScoreUpdated;
    public static event Action<float> OnGameProgressed;
    
    public static event Action<PlayerData> OnGameProgression;
    public static event Action<PlayerData> OnGameLoaded;
    
    public static void SendOnGameProgressed(float value)
    {
        OnGameProgressed?.Invoke(value);
    }
    
    public static void SendOnGameProgression(PlayerData value)
    {
        OnGameProgression?.Invoke(value);
    }
    
    public static void SendOnGameLoaded(PlayerData value)
    {
        OnGameLoaded?.Invoke(value);
    }
}