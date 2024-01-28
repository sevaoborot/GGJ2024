using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MG01_BikerMovement : MonoBehaviour, GameInput.IMinigame01Actions
{
    [Header("Biker Setup")]
    [SerializeField] List<Vector3> BikerPositions = new List<Vector3>();
    [SerializeField] GameObject levelTimer;
    [Header("Lose screen")]
    [SerializeField] List<GameObject> LosingPics = new List<GameObject>();

    GameInput gameInput;
    int currentPosition;

    GameObject LifesCounter;

    private void OnEnable()
    {
        LifesCounter = GameObject.Find("LevelController");
        if (gameInput == null)
        {
            gameInput = new GameInput();
            gameInput.Minigame01.SetCallbacks(this);
        }
        gameInput.Minigame01.Enable();
    }

    private void OnDisable() => gameInput.Minigame01.Disable();

    void Start()
    {
        currentPosition = 1;
        transform.position = BikerPositions[1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelTimer.GetComponent<LevelTimer>().enabled = false;
        StartCoroutine(FailPics());
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.performed && currentPosition > 0)
        {
            currentPosition--;
            transform.position = BikerPositions[currentPosition];
        }
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.performed && currentPosition < BikerPositions.Count - 1)
        {
            currentPosition++;
            transform.position = BikerPositions[currentPosition];
        }
    }

    IEnumerator FailPics()
    {
        Instantiate(LosingPics[0], Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(LosingPics[1], Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(LosingPics[2], Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        LifesCounter.GetComponent<SceneControllerScript>().lifesNumber--;
        SceneManager.LoadScene(1);
    }
}