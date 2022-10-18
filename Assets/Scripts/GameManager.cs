using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _canvas;
    private bool _isPaused;
    
    private void Start()
    {
        _canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("P"))
        {
            _isPaused = !_isPaused;
            if (_isPaused)
            {
                //display canvas
            }
            else
            {
                //hide canvas
            }
        }  
    }
}
