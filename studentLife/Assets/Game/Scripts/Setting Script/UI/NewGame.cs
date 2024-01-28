using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void loadRandomGame() => SceneManager.LoadScene(Random.Range(minInclusive: 2, SceneManager.sceneCountInBuildSettings));
}
