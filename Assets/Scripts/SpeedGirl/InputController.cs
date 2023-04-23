using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    #region Parameters
    
    private float dirX;
    private float dirY;
    private float mouseX;
    private float mouseY;
    private AnimatorController animController;
    private MovementController moveController;
    private bool canJump;

    #endregion

    private void Start()
    {
        canJump = true;
        animController = GetComponent<AnimatorController>();
        moveController = GetComponent<MovementController>();
    }

    private void Update()
    {
        dirY = Input.GetAxis("Vertical");
        dirX = Input.GetAxis("Horizontal");
        
        if(dirY > 0) moveController.MoveForward();
        else if(dirY < 0) moveController.MoveBack();
        
        if(dirX > 0) moveController.MoveRight();
        else if(dirX < 0) moveController.MoveLeft();
        
        if(Input.GetButton("Jump") && canJump)
        {
            moveController.Jump();
            canJump = false;
        }

        if (Input.GetButton("Crouch") && canJump)
        {
            moveController.Crouch();
        }
        
    }

    public bool isJumping()
    {
        return !canJump;
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Ground")) canJump = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) canJump = false;
    }
}
