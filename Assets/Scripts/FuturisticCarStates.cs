using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuturisticCarStates : MonoBehaviour
{
    private MovementController moveController;

    private void Awake()
    {
        moveController = GetComponent<MovementController>();
    }

    private void FixedUpdate()
    {
        moveController.MoveForward();
    }
}
