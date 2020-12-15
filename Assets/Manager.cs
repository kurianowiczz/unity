using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] persons;
    [SerializeField] private GameObject[] flowers;

    private List<Vector3> startPersonPositions = new List<Vector3>();

    public static Manager instance;

    private void Start()
    {
        instance = this;
        foreach (var person in persons)
        {
            var pos = person.transform.position;
            startPersonPositions.Add(pos);
        }
    }

    public void Restart()
    {
        int i = 0;
        foreach (var person in persons)
        {
            person.transform.position = startPersonPositions[i];
            person.transform.rotation = Quaternion.identity;
            i++;
        }

        foreach (var flower in flowers)
        {
            flower.SetActive(true);
        }
    }
}
