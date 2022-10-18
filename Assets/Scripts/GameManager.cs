using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Image _pauseScreen;
    private bool _isPaused = false;
    private bool _isPausable = true;
    
    private void Start()
    {
        _pauseScreen = GameObject.Find("Canvas").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) && _isPausable)
        {
            //prevent additional pauses for a certain period of time
            _isPausable = false;
            //start a timer to re-enable isPausable after 2s
            StartCoroutine(ReEnablePause(0.5f));
            
            //change pause state
            _isPaused = !_isPaused;
            if (_isPaused)
            {
                //display canvas
                _pauseScreen.enabled = true;
            }
            else
            {
                //hide canvas
                _pauseScreen.enabled = false;
            }
        }  
    }

    IEnumerator ReEnablePause(float duration)
    {
        yield return new WaitForSeconds(duration);
        _isPausable = true;
    }
}
