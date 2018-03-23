using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject robotPrefab;
    public RobotManager[] Players;

    private GameObject inventoryImage;

    void Start ()
    {
        SpawnRobots();
    }

    private void SpawnRobots()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].Instance = 
                Instantiate(robotPrefab, Players[i].robotSpawnPoint.position,
                Players[i].robotSpawnPoint.rotation) as GameObject;

            Players[i].Instance.AddComponent<PlayerInventory>();//give each player an inventory
            Players[i].Instance.AddComponent<PointSystem>();//give each player a point system
            Players[i].Instance.AddComponent<SetUIForPlayers>();//give each player an Inventory??
            Players[i].playerNumber = i + 1;
            Players[i].Setup();           
        }
    }
}
