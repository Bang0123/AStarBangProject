﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public LayerMask Mask;
    public Transform Target;
    Camera _cam;
    public bool OnlyOnDoubleClick;

    public void Start()
    {
        _cam = Camera.main;
        Target = GetComponent<Transform>();
        useGUILayout = false;
    }

    public void OnGUI()
    {
        if (OnlyOnDoubleClick && _cam != null && Event.current.type == EventType.MouseDown && Event.current.clickCount == 2)
        {
            UpdateTargetPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!OnlyOnDoubleClick && _cam != null)
        {
            UpdateTargetPosition();
        }
    }

    public void UpdateTargetPosition()
    {
        Vector3 newPosition = Vector3.zero;
        bool positionFound = false;

        //Fire a ray through the scene at the mouse position and place the target where it hits
        RaycastHit hit;
        if (Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, Mask))
        {
            newPosition = hit.point;
            positionFound = true;
        }

        if (positionFound && newPosition != Target.position)
        {
            Target.position = newPosition;
        }
    }
}