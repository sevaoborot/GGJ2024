using System.Collections;
using UnityEngine;

public class MG02_TutorController : MonoBehaviour
{
    [SerializeField] float TimeToDetectCheating;
    [SerializeField] float TimepieceNotToDetectCheating;
    [SerializeField] LevelTimer levelTimer;

    SpriteRenderer colorGreybox;
    bool shouldCheckForCheating = true;
    bool isChecking = true;

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
                yield return new WaitForSeconds(1f);
            }
            if (temp == 1)
            {
                colorGreybox.color = Color.red;
                yield return new WaitForSeconds(Random.Range(0.75f, TimeToDetectCheating));
                colorGreybox.color = Color.white;
            }
        }
    }
}