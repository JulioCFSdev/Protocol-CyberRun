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
    private CapsuleCollider coll;
    private Vector3 collCenter = new Vector3(0, 9, 0);

    #endregion
    
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
    }

    private void ResetColl()
    {
        coll.center = collCenter;
        coll.height = collCenter.y * 2;
    }

    public void MoveForward()
    {
        Vector3 dir = (rig.velocity.normalized + transform.forward).normalized * (speedModifier);
        rig.velocity = new Vector3(dir.x,rig.velocity.y,dir.z);
    }
    
    public void MoveBack()
    {
        Vector3 dir = (rig.velocity.normalized - transform.forward).normalized * (speedModifier);
        rig.velocity = new Vector3(dir.x,rig.velocity.y,dir.z);
    }
    
    public void MoveRight()
    {
        Vector3 dir = (rig.velocity.normalized + transform.right).normalized * (speedModifier * 0.8f);
        rig.velocity = new Vector3(dir.x,rig.velocity.y,dir.z);
    }
    
    public void MoveLeft()
    {
        Vector3 dir = (rig.velocity.normalized - transform.right).normalized * (speedModifier * 0.8f);
        rig.velocity = new Vector3(dir.x,rig.velocity.y,dir.z);
    }
    
    public void Jump()
    {
        Vector3 dir = rig.velocity;
        dir = new Vector3(dir.x,jumpModifier,dir.z);
        rig.velocity = dir;
    }

    public void RotationX(float rotationY)
    {
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
    
    public void Crouch()
    {
        coll.center = collCenter / 2;
        coll.height = collCenter.y;
        Invoke("ResetColl", 1f);

        rig.velocity = rig.velocity * 1.3f;
    }
}
