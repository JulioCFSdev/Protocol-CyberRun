using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FuturisticCarStates : MonoBehaviour
{
    private MovementController moveController;
    private void Start()
    {
        moveController = GetComponent<MovementController>();
    }

    private void FixedUpdate()
    {
        moveController.MoveForward();
    }
}
