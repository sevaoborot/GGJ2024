using UnityEngine;
using UnityEngine.InputSystem;

public class MG02_Cheating : MonoBehaviour, GameInput.IMinigame02Actions
{
    [SerializeField] float FullCheatMaxTime;
    [SerializeField] float MaxCheatValue;

    GameInput gameInput;
    SpriteRenderer colorGreybox;

    bool isHeld;
    float currentCheatValue;

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
            gameInput.Minigame02.SetCallbacks(this);
        }
        gameInput.Minigame02.Enable();
    }

    private void OnDisable() => gameInput.Minigame02.Disable();

    void Start() => colorGreybox = GetComponent<SpriteRenderer>();

    void Update()
    {
        if (isHeld) currentCheatValue += CalculatePercentOfCheating(Time.deltaTime);
        if (currentCheatValue >= MaxCheatValue) Debug.Log("Cheat SUCCESS!!!");
    }

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