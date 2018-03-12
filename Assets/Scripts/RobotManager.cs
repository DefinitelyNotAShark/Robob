using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class RobotManager {

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
        rectTransform = imageInstance.GetComponentInChildren<RectTransform>();//this is where I set my position
        rectTransform.SetParent(myCanvas.transform);

        if (playerNumber == 1)
        {
            rectTransform.offsetMin = new Vector2(0, 0);
        }

        else if (playerNumber == 2)
        {
            rectTransform.offsetMin = new Vector2(Screen.width, 0);
        }

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
