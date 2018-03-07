using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text text;
    public int itemsToBring = 3;//change to 9 eventually
    public MoveCamera cameraControl;
    public GameObject robotPrefab;

    public RobotManager[] Players;

	// Use this for initialization
	void Start () {
        SpawnRobots();
        SetCameraTargets();
    }

    private void SpawnRobots()
    {
        for(int i = 0; i < Players.Length; i++)
        {
            Players[i].Instance = 
                Instantiate(robotPrefab, Players[i].robotSpawnPoint.position,
                Players[i].robotSpawnPoint.rotation) as GameObject;
            Players[i].playerNumber = i + 1;
            Players[i].Setup();
        }
    }

    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[Players.Length];//makes a transform for each robot

        for(int i = 0; i < targets.Length; i++)
        {
            targets[i] = Players[i].Instance.transform; 
        }

        cameraControl.Players = targets; 
    }

}
