using System.Collections;
using UnityEngine;

public class MG02_TutorController : MonoBehaviour
{
    [SerializeField] float TimeToDetectCheating;
    [SerializeField] float TimepieceNotToDetectCheating;
    [SerializeField] LevelTimer levelTimer;

    SpriteRenderer colorGreybox;
    bool shouldCheckForCheating = true;
    int maxNumberOfPausesInARaw = 4;
    int currentNumberOfPausesInARaw = 0;

    private void OnEnable() => levelTimer.OnTimerIsOver += TimerIsOver;
    private void OnDisable() => levelTimer.OnTimerIsOver -= TimerIsOver;

    void TimerIsOver()
    {
        shouldCheckForCheating = false;
        Debug.Log("Time is over!");
        colorGreybox.color = Color.green;
    }

    void Start()
    {
        colorGreybox = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (shouldCheckForCheating) {
            int temp = Random.Range(0, 1); //i guess smth with the random
            Debug.Log(temp);
            if (temp == 0 && currentNumberOfPausesInARaw < maxNumberOfPausesInARaw) StartCoroutine(PausesTimer());
            if (temp == 1) StartCoroutine(DetectionTime());
        }
    }

    IEnumerator PausesTimer()
    {
        yield return new WaitForSeconds(0.5f);
        currentNumberOfPausesInARaw++;
    }

    IEnumerator DetectionTime()
    {
        colorGreybox.color = Color.red;
        yield return new WaitForSeconds(Random.Range(0.75f, TimeToDetectCheating));
        colorGreybox.color = Color.white;
    }
}