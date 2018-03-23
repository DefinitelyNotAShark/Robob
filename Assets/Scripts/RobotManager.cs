using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class RobotManager
{
    public Color playerColor;
    public Transform robotSpawnPoint;

    public Canvas myCanvas;

    [HideInInspector] public int playerNumber;
    [HideInInspector] public string coloredRobotText;
    [HideInInspector] public GameObject Instance;

    [HideInInspector] public GameObject imageInstance;
    [HideInInspector] public RectTransform rectTransform;

    private MovePlayer playerMovement;
    private Shoot playerShooting;


    public void Setup()
    {
        playerMovement = Instance.GetComponent<MovePlayer>();
        playerShooting = Instance.GetComponent<Shoot>();

        playerMovement.playerNumber = playerNumber;
        playerShooting.playerNumber = playerNumber;

        coloredRobotText = "<color=#" + ColorUtility.ToHtmlStringRGB(playerColor) + ">player " + playerNumber + "</color>";

        MeshRenderer[] renderers = Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = playerColor;
        }
    }
}
