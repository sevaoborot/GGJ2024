using UnityEngine;

public class SceneControllerScript: MonoBehaviour
{
    public static SceneControllerScript instance;

    public int lifesNumber = 3;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
