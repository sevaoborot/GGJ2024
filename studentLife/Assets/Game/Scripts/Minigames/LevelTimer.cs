using System;
using System.Collections;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] float LevelLifetime;

    public Action OnTimerIsOver;

    void Start()
    {
        StartCoroutine(Timer()); 
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(LevelLifetime);
        OnTimerIsOver?.Invoke();
    }
}
