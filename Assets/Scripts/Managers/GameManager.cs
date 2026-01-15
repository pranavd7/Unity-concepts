using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    private int score = 0;
    
    public void AddScore(int amount)
    {
        score += amount;
    }

    public int GetScore()
    {
        return score;
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public override void Init()
    {
        
    }
}
