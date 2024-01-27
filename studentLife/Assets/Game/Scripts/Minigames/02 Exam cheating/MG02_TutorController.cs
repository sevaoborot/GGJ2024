using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class MG02_TutorController : MonoBehaviour
{
    [SerializeField] float TimeToDetectCheating;
    [SerializeField] LevelTimer levelTimer;

    public Action OnCheckingOn;
    public Action OnCheckingOff;

    SpriteRenderer colorGreybox;
    bool shouldCheckForCheating = true;

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
        StartCoroutine(TutorTimer());
    }

    IEnumerator TutorTimer()
    {
        while (shouldCheckForCheating)
        {
            int temp = Random.Range(minInclusive: 0, maxExclusive: 2);
            if (temp==0)
            {
                colorGreybox.color = Color.white;
                OnCheckingOff?.Invoke();
                yield return new WaitForSeconds(1f);
            }
            if (temp == 1)
            {
                colorGreybox.color = Color.red;
                yield return new WaitForSeconds(0.5f); //like a small time for reaction
                OnCheckingOn?.Invoke();
                yield return new WaitForSeconds(Random.Range(0.75f, TimeToDetectCheating));
                colorGreybox.color = Color.white;
            }
        }
    }
}