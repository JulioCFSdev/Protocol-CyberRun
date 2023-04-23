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
    private bool canWallJump;
    private bool canDash = true;

    private float jumpCD = .25f;
    private float timeToJump;

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
        
        if(dirY > 0.1f) moveController.MoveForward();
        else if(dirY < -0.1f) moveController.MoveBack();
        
        if(dirX > 0.1f) moveController.MoveRight();
        else if(dirX < -0.1f) moveController.MoveLeft();
        
        if(Input.GetButton("Jump") && canJump && canDash && timeToJump <= 0)
        {
            timeToJump = jumpCD;
            moveController.Jump();
            canJump = false;
        }

        if (Input.GetButton("Crouch") && canJump)
        {
            moveController.Crouch();
            TriggerDash();
        }
        
    }

    private void FixedUpdate()
    {
        if (timeToJump > 0) timeToJump -= Time.fixedDeltaTime;
    }

    public bool isJumping()
    {
        return !canJump;
    }
    
    public bool isDashing()
    {
        return !canDash;
    }
    
    private void TriggerDash()
    {
        canDash = false;
        Invoke("DisableDash",1.5f);
    }

    private void DisableDash()
    {
        canDash = true;
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Ground")) canJump = true;
        if (collisionInfo.collider.CompareTag("Wall")) canJump = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) canJump = false;
        if (other.gameObject.CompareTag("Wall")) canJump = false;
    }
}