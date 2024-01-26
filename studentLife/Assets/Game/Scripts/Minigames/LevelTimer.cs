using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] float LevelLifetime;

    void Start()
    {
        StartCoroutine(Timer()); 
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(LevelLifetime);
    }
}
