using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake()
    {
                int numberScenePersist = FindObjectsByType<ScenePersist>(FindObjectsSortMode.None).Length;
        if (numberScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
