using UnityEngine;

public class MG03_HidingSinc : MonoBehaviour
{
    [SerializeField] MG03_HidingObj hidingObj1;
    [SerializeField] MG03_HidingObj hidingObj2;
    [SerializeField] MG03_HidingObj hidingObj3;

    int placesTaken = 0;

    private void OnEnable()
    {
        hidingObj1.OnInTrigger += placesNum;
        hidingObj2.OnInTrigger += placesNum;
        hidingObj3.OnInTrigger += placesNum;
    }

    private void OnDisable()
    {
        hidingObj1.OnInTrigger -= placesNum;
        hidingObj2.OnInTrigger -= placesNum;
        hidingObj3.OnInTrigger -= placesNum;
    }

    void placesNum() => placesTaken++;

    private void Update()
    {
        if (placesTaken == 3) Debug.Log("Success!!!");
    }
}
