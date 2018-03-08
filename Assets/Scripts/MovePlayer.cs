﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    [SerializeField]
    public int playerNumber = 1;

    [SerializeField]
    private float speed = 12f;

    [SerializeField]
    public float turnSpeed = 180f;

    private string movementAxisName;
    private string turnAxisName;
    private Rigidbody rigidbody;
    private float movementInputValue;
    private float turnInputValue;
    private int xboxOneController = 0;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start ()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == 33)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                xboxOneController = 1;
            }
        }

        if (xboxOneController == 1)
        {
            movementAxisName = "TempVertical" + playerNumber;
            turnAxisName = "TempHorizontal" + playerNumber;
        }
        else
        {
            movementAxisName = "Vertical" + playerNumber;
            turnAxisName = "Horizontal" + playerNumber;
        }

    }

    // Update is called once per frame
    void Update ()
    { 
        movementInputValue = Input.GetAxis(movementAxisName);//stores my input
        turnInputValue = Input.GetAxis(turnAxisName);
    }

    private void OnEnable()//able to move
    {
        rigidbody.isKinematic = false;
        movementInputValue = 0f;
        turnInputValue = 0f;
    }

    private void OnDisable()//unable to move
    {
        rigidbody.isKinematic = true;
    }

    private void FixedUpdate()
    {
        // Move and turn player
        Move();
        Turn();
    }

    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.

        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
    }

    private void Move()
    {
        Vector3 movement = transform.forward * movementInputValue * speed * Time.deltaTime;//sets a vector3 to forward times input value
        rigidbody.MovePosition(rigidbody.position + movement);//moves my rigidbody the vector3
    }
}
