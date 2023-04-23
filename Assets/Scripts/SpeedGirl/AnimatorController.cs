using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    #region Parameters

    private Animator anim;
    private Rigidbody rig;
    private InputController inputController;

    #endregion
    
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        inputController = GetComponent<InputController>();
    }

    private void Update()
    {
        if(!inputController.isJumping())
        {
            if (rig.velocity == Vector3.zero) anim.Play("Idle");
            else if (rig.velocity != Vector3.zero && (IsCurrentAnim("Idle") || IsCurrentAnim("Falling Idle"))) anim.Play("IdleToSprint");
        } else if(!(IsCurrentAnim("Running Jump") || IsCurrentAnim("Falling Idle"))) anim.Play("Running Jump");
    }

    private bool IsCurrentAnim(string animName)
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }
}
