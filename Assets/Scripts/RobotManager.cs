using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RobotManager : MonoBehaviour {

    public Color playerColor;
    public Transform robotSpawnPoint;

    [HideInInspector]
    public int playerNumber;

    [HideInInspector]
    public string coloredRobotText;

    [HideInInspector]
    public GameObject Instance;

    private MovePlayer playerMovement;
    private Shoot playerShooting;
    private GameObject canvasGameObject;

    // Use this for initialization
    void Start () {
		
	}
	
    public void Setup()
    {
        playerMovement = Instance.GetComponent<MovePlayer>();
        playerShooting = Instance.GetComponent<Shoot>();
        canvasGameObject = Instance.GetComponentInChildren<Canvas>().gameObject;

        playerMovement.playerNumber = playerNumber;
        playerShooting.playerNumber = playerNumber;

        coloredRobotText = "<color=#" + ColorUtility.ToHtmlStringRGB(playerColor) + ">player " + playerNumber + "</color>";

        MeshRenderer[] renderers = Instance.GetComponentsInChildren<MeshRenderer>();

        for(int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = playerColor;
        }

    }
}
