﻿using UnityEngine;
using System.Collections;

public class MouseSwipe : MonoBehaviour {

    public LineRenderer _lineRender;
    public int _count = 2;

    private Vector3[] vertecies = null;
    [HideInInspector]
    private bool firstFrameElse = true;

	// Use this for initialization
	void Start () {
        _lineRender = GetComponent<LineRenderer>();
        transform.rotation = Camera.main.transform.rotation;

        vertecies = new Vector3[_count];
        _lineRender.SetVertexCount(_count);
        _lineRender.SetWidth(0.5f, 0.01f);

        firstFrameElse = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (MouseController.Instance.buttonDown)
        {
            if (!firstFrameElse)    // första frame efter att man tryck ned knappen igen
            {
                // sätter alla linjer i muspositionen
                for (int i = 0; i < _count; i++)
                {
                    vertecies[i] = MouseController.Instance.worldPosition + (Camera.main.transform.forward * 5);
                    _lineRender.SetPosition(i, vertecies[i]);
                }
            }
            firstFrameElse = true;

            // första linjen sätts till musen
            vertecies[0] = MouseController.Instance.worldPosition + (Camera.main.transform.forward * 5);
            _lineRender.SetPosition(0, vertecies[0]);

            // alla andra linjer sätts till föregående linje
            for (int i = _count - 1; i > 0; i--)
            {
                vertecies[i] = vertecies[i - 1];
                _lineRender.SetPosition(i, vertecies[i]);
            }
        }
        else
        {
            if (firstFrameElse)     // första frame man släppt knappen
            {
                firstFrameElse = false;
                // flyttar alla linjer utanför skärmen
                for (int i = 0; i < _count; i++)
                {
                    vertecies[i] = new Vector3(-1, -1, -1);
                    _lineRender.SetPosition(i, vertecies[i]);
                }
            }
        }
	}
}
