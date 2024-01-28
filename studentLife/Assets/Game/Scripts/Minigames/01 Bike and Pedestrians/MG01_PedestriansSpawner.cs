using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MG01_PedestriansSpawner : MonoBehaviour
{
    [Header("Spawning Setup")]
    [SerializeField] List<GameObject> Pedestrians = new List<GameObject>();
    [SerializeField] List<Vector3> SpawnerPositions = new List<Vector3>();
    [Header("Level Setup")]
    [SerializeField] LevelTimer levelTimer;
    [Header("LevelSuccess")]
    [SerializeField] GameObject SuccessPic;

    int lastSpawner = -1;
    float lastTimerLimit = 2f; //should change it after event call
    bool shouldSpawnPedestrians = true;

    void OnEnable() => levelTimer.OnTimerIsOver += TimerIsOver;
    void OnDisable() => levelTimer.OnTimerIsOver -= TimerIsOver;

    void Start()
    {
        StartCoroutine(InstantiatePedestrians());
    }

    void TimerIsOver()
    {
        shouldSpawnPedestrians = false;
        StartCoroutine(LevelSuccess());
    }

    IEnumerator InstantiatePedestrians()
    {
        while (shouldSpawnPedestrians)
        {
            Instantiate(Pedestrians[Random.Range(0, Pedestrians.Count)], SpawnerPositions[Random.Range(0, SpawnerPositions.Count)], Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.3f, lastTimerLimit));
        }
    }

    IEnumerator LevelSuccess()
    {
        Instantiate(SuccessPic, Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}