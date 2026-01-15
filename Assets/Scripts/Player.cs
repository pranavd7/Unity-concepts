using UnityEngine;

public delegate void PlayerDied();

public class Player : MonoBehaviour
{

    // [SerializeField] GameManager gameManager;

    [SerializeField] AudioClip clip;
    
    
    public static event PlayerDied OnPlayerDeath;
    

    public void Start()
    {
        GameManager.Instance.AddScore(10);
        AudioManager.Instance.PlaySFX(clip);

        // FileManager.Instance.ReadFile("savepath"); 
    }
}