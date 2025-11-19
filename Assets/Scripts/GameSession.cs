using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    int playerLives = 3;

    [SerializeField] TextMeshProUGUI livesText;

    void Awake()
    {
        int numberGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
    }

    void Update()
    {

    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
         Invoke(nameof(TakeLife), .5f);
        }
        else
        {
            ResetGameSession();
            
        }
    }

    void TakeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
    }
    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        FindFirstObjectByType<ScenePersist>().ResetScenePersist();
    }
}
