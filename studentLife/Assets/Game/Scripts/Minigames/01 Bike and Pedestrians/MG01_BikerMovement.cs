using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MG01_BikerMovement : MonoBehaviour, GameInput.IMinigame01Actions
{
    [SerializeField] List<Vector3> BikerPositions = new List<Vector3>();

    GameInput gameInput;
    int currentPosition;

    private void OnEnable()
    {
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
}