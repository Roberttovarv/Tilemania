using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitLevel : MonoBehaviour
{
    public int currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(currentScene + 1);
        FindFirstObjectByType<ScenePersist>().ResetScenePersist();

    }
}
