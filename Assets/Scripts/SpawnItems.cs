using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField]
    private GameObject batteryPrefab;
    [SerializeField]
    private GameObject gearPrefab;
    [SerializeField]
    private GameObject wirePrefab;

    private List<Transform> wireSpawnPoints;
    private List<Transform> gearSpawnPoints;
    private List<Transform> batterySpawnPoints;

    private Transform wireSpawnPoint;
    private Transform gearSpawnPoint;
    private Transform batterySpawnPoint;

    private void Start()
    {
        wireSpawnPoints = new List<Transform>();
        gearSpawnPoints = new List<Transform>();
        batterySpawnPoints = new List<Transform>();

        AddSpawnPoints();//adds spawn points to the list
        PickRandomSpawnPoints();
        SpawnAtRandomPoint(wireSpawnPoint, gearSpawnPoint, batterySpawnPoint);
    }

    void AddSpawnPoints()
    {
        foreach(Transform child in transform)
        {
            if (child.CompareTag("wire"))//if the game object is tagged with wire
                wireSpawnPoints.Add(child);//add it to wirespawn points

            if (child.CompareTag("battery"))//if the game object is tagged with battery
                batterySpawnPoints.Add(child);//add it to wirespawn points

            if (child.CompareTag("gear"))//if the game object is tagged with gear
                gearSpawnPoints.Add(child);//add it to wirespawn points
        }
    }

    private void SpawnAtRandomPoint(Transform wire, Transform gear, Transform battery)
    {
        (Instantiate(wirePrefab, wire.position, wire.rotation) as GameObject).transform.parent = wireSpawnPoint.transform;
        (Instantiate(gearPrefab, gear.position, gear.rotation) as GameObject).transform.parent = gearSpawnPoint.transform;
        (Instantiate(batteryPrefab, battery.position, battery.rotation) as GameObject).transform.parent = batterySpawnPoint.transform;
    }

    void PickRandomSpawnForWire()
    {
        int wireInt = UnityEngine.Random.Range(0, 3);
        wireSpawnPoint = wireSpawnPoints[wireInt];
    }

    void PickRandomSpawnForGear()
    {
        int gearInt = UnityEngine.Random.Range(0, 3);
        gearSpawnPoint = gearSpawnPoints[gearInt];
    }

    void PickRandomSpawnForBattery()
    {
        int batteryInt = UnityEngine.Random.Range(0, 3);
        batterySpawnPoint = batterySpawnPoints[batteryInt];
    }

    void PickRandomSpawnPoints()
    {
        PickRandomSpawnForWire();//get all them spawn points
        PickRandomSpawnForBattery();
        PickRandomSpawnForGear();
    }
}
