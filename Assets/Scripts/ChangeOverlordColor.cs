using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOverlordColor : MonoBehaviour {

    [SerializeField]
    public Color normalColor;

    [SerializeField]
    public Color correctColor;

    [SerializeField]
    public Color wrongColor;

    public MeshRenderer[] renderers;

	// Use this for initialization
	void Start ()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();
        for(int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = normalColor;
        }
    }

    public IEnumerator CorrectAnswer()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = correctColor;
        }
        yield return new WaitForSeconds(1);
        GoBackToNormal();

    }

    public IEnumerator WrongAnswer()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = wrongColor;
        }
        yield return new WaitForSeconds(1);
        GoBackToNormal();
    }

    void GoBackToNormal()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = normalColor;
        }
    }

    private void Update()
    {
        CheckIfNeedToChangeColor();
    }

    private void CheckIfNeedToChangeColor()
    {
        //if correct item was given, start coroutine right answer
        //else if wrong item was given, start coroutine wrong answer
    }
}
