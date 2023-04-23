using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region Parameters

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offsetFP;
    [SerializeField] private float smoothModifier;
    
    #endregion

    private void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, playerTransform.position + offsetFP, smoothModifier);
        transform.position = playerTransform.position + offsetFP;
    }
}
