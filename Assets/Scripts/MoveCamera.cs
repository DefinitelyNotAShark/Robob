using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    [SerializeField]
    private float dampTime = 2f;//smoothes the movements of the camera

    [SerializeField]
    private float screenEdgeBuffer = 4f; //so the camera doesn't always touch the corner of the player

    [SerializeField]
    private float minCameraSize = 7f;

    public Transform[] Players;

    private Camera camera;
    private float zoomSpeed = 2f;
    private Vector3 moveVelocity;
    private Vector3 desiredPosition;



    private void Awake()
    {
        camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Move();
       Zoom(); //Fuck man this shit dont work i cant even it zooms out wayyyyy to much
    }

    private void Move()
    {
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
    }
    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, requiredSize, ref zoomSpeed, dampTime);
    }

    private float FindRequiredSize()//something in this function makes it zoom WAY too m
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(desiredPosition);//makes the desired local an inverse of desired pos
        float size = 0f;

        for (int i = 0; i < Players.Length; i++)//for each player in the game
        {
            if (!Players[i].gameObject.activeSelf)//if this player isn't active, then whatever...
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(Players[i].position);//else put local position at inverse of my position
            Vector3 desiredPosToPlayer = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size, Mathf.Abs(desiredPosToPlayer.y));//takes biggest number between the size and the desired position to player
            size = Mathf.Max(size, Mathf.Abs(desiredPosToPlayer.x) / camera.aspect);//find biggest number between size and desired position to player
        }

        size += screenEdgeBuffer;
        size = Mathf.Max(size, minCameraSize);//this MIGHT BE WRONG CHECK THIS IF IT DONT WORKKKKK
        return size;
    }

    private void FindAveragePosition()
    {
        Vector3 averagePosition = new Vector3();
        int numPlayers = 0;

        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i].gameObject.activeSelf)//if this player is active, don't do the next thing
                continue;

            averagePosition += Players[i].position;//average position plus player position
            numPlayers++;//add another player
        }

        if (numPlayers > 0)//if there's at least one player
            averagePosition /= numPlayers;//then average position cant be equal to num of players

        averagePosition.y = transform.position.y;//the avg position of y needs to match this y
        desiredPosition = averagePosition;//this desired position needs to be average position
    }

    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = desiredPosition;//sets position to desired position
        camera.orthographicSize = FindRequiredSize();
    }
}
