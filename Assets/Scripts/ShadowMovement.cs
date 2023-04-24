using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowMovement : MonoBehaviour
{
    #region Parameters

    [SerializeField] private Transform playerPos;
    private Vector3 offset;
    private List<Vector3> PositionsHistory = new List<Vector3>();
    [SerializeField] private int Gap = 200;
    private Rigidbody rig;
    private float timer = 2;

    #endregion

    private void Start()
    {
        offset = Vector3.up*5;
    }

    private void FixedUpdate()
    {
        PositionsHistory.Insert(0, playerPos.transform.position);

        int index = 1;
        Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)] + offset;
        
        
        if (timer < 0)
        {
            transform.position = Vector3.Lerp(transform.position, point, 0.8f);
        }
        else timer -= Time.deltaTime;
    }

    private void GameOver()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) GameOver();
    }
}
