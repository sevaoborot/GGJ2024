using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG01_PedestriansSpawner : MonoBehaviour
{
    [Header("Spawning Setup")]
    [SerializeField] List<GameObject> Pedestrians = new List<GameObject>();
    [SerializeField] List<Vector3> SpawnerPositions = new List<Vector3>();
    [Header("LevelSetup")]
    [SerializeField] float TimeForLevel;

    int lastSpawner = -1;

    float lastTimerLimit = 3f; //should change it after event call

    private bool shouldSpawnPedestrians = true;

    void Start()
    {
        StartCoroutine(PedestriansSpawner());
        StartCoroutine(InstantiatePedestrian());
    }

    IEnumerator PedestriansSpawner()
    {
        shouldSpawnPedestrians = true;
        yield return new WaitForSeconds(TimeForLevel);
        shouldSpawnPedestrians = false;
    }

    IEnumerator InstantiatePedestrian()
    {
        while (shouldSpawnPedestrians)
        {
            Instantiate(Pedestrians[Random.Range(0, Pedestrians.Count - 1)], SpawnerPositions[CheckIfLastSpawner()], Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.5f, lastTimerLimit));
        }
    }

    int CheckIfLastSpawner()
    {
        int temp;
        do
        {
            temp = Random.Range(0, SpawnerPositions.Count - 1);
        } while (temp != lastSpawner);
        lastSpawner = temp;
        return temp;
    }
}