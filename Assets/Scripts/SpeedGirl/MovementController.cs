using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovementController : MonoBehaviour
{
    #region Parameters

    [Range(30,120)]
    [SerializeField] private float speedModifier;
    [Range(0,1)]
    [SerializeField] private float turnModifier;
    [Range(1,1500)]
    [SerializeField] private float jumpModifier;

    private Rigidbody rig;

    #endregion

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 dir = rig.velocity;
        dir = new Vector3(dir.x,dir.y - 10,dir.z);
        rig.velocity = dir;
    }

    public void MoveForward()
    {
        Vector3 dir = rig.velocity;
        dir = new Vector3(dir.x,dir.y,speedModifier);
        rig.velocity = dir;
    }
    
    public void MoveBack()
    {
        Vector3 dir = rig.velocity;
        dir = new Vector3(dir.x,dir.y,speedModifier * -1);
        rig.velocity = dir;
    }
    
    public void MoveRight()
    {
        Vector3 dir = rig.velocity;
        dir = new Vector3(speedModifier * 0.6f,dir.y,dir.z);
        rig.velocity = dir;
    }
    
    public void MoveLeft()
    {
        Vector3 dir = rig.velocity;
        dir = new Vector3(speedModifier * -0.6f,dir.y,dir.z);
        rig.velocity = dir;
    }

    public void Jump()
    {
        Vector3 dir = rig.velocity;
        dir = new Vector3(dir.x,jumpModifier,dir.z);
        rig.velocity = Vector3.Lerp(rig.velocity, dir, 0.2f);
    }
}
