using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MG02_Cheating : MonoBehaviour, GameInput.IMinigame02Actions
{
    [Header("Cheating stats")]
    [SerializeField] float FullCheatMaxTime;
    [SerializeField] float MaxCheatValue;
    [Header("Necessary refs")]
    [SerializeField] MG02_TutorController TutorController;
    [SerializeField] LevelTimer LevelTimer;

    GameInput gameInput;
    SpriteRenderer colorGreybox;

    bool isHeld;
    bool isCheatingOn = false;
    bool shouldCheat = true;
    [SerializeField]float currentCheatValue;

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
            gameInput.Minigame02.SetCallbacks(this);
        }
        gameInput.Minigame02.Enable();

        TutorController.OnCheckingOn += CheatingOff;
        TutorController.OnCheckingOff += CheatingOn;
        LevelTimer.OnTimerIsOver += TimerIsOver;
    }

    private void OnDisable()
    {
        gameInput.Minigame02.Disable();

        TutorController.OnCheckingOn -= CheatingOff;
        TutorController.OnCheckingOff -= CheatingOn;
        LevelTimer.OnTimerIsOver -= TimerIsOver;
    } 

    void Start()
    {
        colorGreybox = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (shouldCheat)
        {
            if (isHeld && isCheatingOn) currentCheatValue += CalculatePercentOfCheating(Time.deltaTime);
            else if (isHeld && !isCheatingOn) Debug.LogWarning("LOOSER!!!");
            if (currentCheatValue >= MaxCheatValue) Debug.Log("Cheat SUCCESS!!!");
        }
    }

    void CheatingOn() => isCheatingOn = true;
    void CheatingOff() => isCheatingOn = false;
    void TimerIsOver() => shouldCheat = false;

    public void OnCheat(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            colorGreybox.color = Color.red;
            isHeld = true;
        }
        if (context.canceled)
        {
            colorGreybox.color = Color.white;
            isHeld = false;
        }
    }

    float CalculatePercentOfCheating(float holdTime)
    {
        float holdTimeNormalized = Mathf.Clamp01(holdTime / FullCheatMaxTime);
        float holdingCheatValue = holdTimeNormalized * MaxCheatValue;
        return holdingCheatValue;
    }
}