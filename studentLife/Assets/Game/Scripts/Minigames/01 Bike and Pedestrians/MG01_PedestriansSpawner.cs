using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG01_PedestriansSpawner : MonoBehaviour
{
    [Header("Spawning Setup")]
    [SerializeField] List<GameObject> Pedestrians = new List<GameObject>();
    [SerializeField] List<Vector3> SpawnerPositions = new List<Vector3>();
    [Header("Level Setup")]
    [SerializeField] LevelTimer levelTimer;

    int lastSpawner = -1;
    float lastTimerLimit = 3f; //should change it after event call
    bool shouldSpawnPedestrians = true;

    void OnEnable() => levelTimer.OnTimerIsOver += TimerIsOver;
    void OnDisable() => levelTimer.OnTimerIsOver -= TimerIsOver;

    void Start()
    {
        StartCoroutine(InstantiatePedestrians());
    }

    void TimerIsOver() => shouldSpawnPedestrians = false;

    IEnumerator InstantiatePedestrians()
    {
        while (shouldSpawnPedestrians)
        {
            Instantiate(Pedestrians[Random.Range(0, Pedestrians.Count - 1)], SpawnerPositions[CheckIfLastSpawner()], Quaternion.Euler(0, 0, 90f));
            yield return new WaitForSeconds(Random.Range(0.5f, lastTimerLimit));
        }
    }

    int CheckIfLastSpawner()
    {
        int temp;
        do
        {
            temp = Random.Range(0, SpawnerPositions.Count - 1);
        } while (temp == lastSpawner);
        lastSpawner = temp;
        return temp;
    }
}