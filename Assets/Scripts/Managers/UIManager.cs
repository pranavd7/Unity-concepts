using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameEventSO gameEventSO;
    private int currentScore = 0;
    
    public static UIManager Instance{ get; private set; }

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
        
        // Subscribe to the event
        // Enemy.OnEnemyDefeated += UpdateScore;
        // Enemy.OnEnemyDied += OnEnemyDeath;
        gameEventSO?.Register(OnGameEvent);

        GameEvents.OnGameProgressed += UpdateLoadingProgress;
        Player.OnPlayerDeath += ShowGameOver;
    }

    private void UpdateLoadingProgress(float val)
    {
        scoreText.text = $"Loading {val}";
    }

    private void ShowGameOver()
    {
        Debug.Log("Game Over");
    }

    private void OnGameEvent()
    {
        Debug.Log("Game event triggered");
    }

    private void OnDestroy()
    {
        // Unsubscribe
        Enemy.OnEnemyDefeated -= UpdateScore;
        gameEventSO.Unregister(OnGameEvent);
        
        GameEvents.OnGameProgressed -= UpdateLoadingProgress;
        Player.OnPlayerDeath -= ShowGameOver;
    }

    // Event handler
    private void UpdateScore(int score)
    {
        currentScore += score;
        scoreText.text = "Score: " + currentScore;
        Debug.Log("UI updated score: " + currentScore);
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        Debug.Log($"Enemy {enemy.gameObject.name} is defeated");
        // Update UI
    }
}
