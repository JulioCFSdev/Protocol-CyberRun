using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    #region Parameters

    [SerializeField] private Transform playerPos;
    private Vector3 offset;
    private List<Vector3> PositionsHistory = new List<Vector3>();
    [SerializeField] private int Gap = 200;
    private Rigidbody rig;

    #endregion

    private void Start()
    {
        offset = Vector3.up*5;
    }

    private void FixedUpdate()
    {
        
        PositionsHistory.Insert(0,playerPos.transform.position);

        int index = 1;
        Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)] + offset;
        transform.position = Vector3.Lerp(transform.position, point, 0.8f);
    }

    private void GameOver()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) GameOver();
    }
}
