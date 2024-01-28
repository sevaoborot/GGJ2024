using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifesLeftScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lifesNum;
    [SerializeField] TextMeshProUGUI failMessage;
    [SerializeField] List<string> failMessages = new List<string>();
    GameObject LifesCounter;
    int lifesLeft;

    private void OnEnable()
    {
        LifesCounter = GameObject.Find("LevelController");
        lifesLeft = LifesCounter.GetComponent<SceneControllerScript>().lifesNumber;
    }

    void Start()
    {
        lifesNum.SetText($"{lifesLeft}");
        if (lifesLeft > 0) StartCoroutine(LoadNewGame());
        if (lifesLeft == 0) failMessage.SetText(failMessages[Random.Range(minInclusive: 0, failMessages.Count)]);
    }

    IEnumerator LoadNewGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Random.Range(minInclusive: 2, SceneManager.sceneCountInBuildSettings));
    }
}
