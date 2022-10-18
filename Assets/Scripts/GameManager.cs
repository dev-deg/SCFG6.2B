using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Image _pauseScreen;
    private bool _isPausable = true;

    public delegate void PauseDelegate(bool isPaused);
    public event PauseDelegate Pause_State_Changed;
    
    private bool _isPaused = false;
    public bool Paused
    {
        get => _isPaused;
        set
        {
            if (_isPaused != value)
            {
                //Updated isPaused variable
                _isPaused = value;
                //Game Pause
                Time.timeScale = _isPaused ? 0 : 1;
                //Triggering the event
                Pause_State_Changed?.Invoke(value);
            }
            
        }
    }

    private void Start()
    {
        _pauseScreen = GameObject.Find("Canvas").GetComponent<Image>();
        
        //Adding the method PauseListener to listen to Pause_State_Changed
        Pause_State_Changed += PauseListener;
    }
    private void OnDestroy()
    {
        //Removing the method PauseListener to stop listening to Pause_State_Changed
        Pause_State_Changed -= PauseListener;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && _isPausable)
        {
            //prevent additional pauses for a certain period of time
            _isPausable = false;
            //start a timer to re-enable isPausable after 0.5s
            StartCoroutine(ReEnablePause(0.5f));
            
            //change pause state
            Paused = !Paused;
            if (Paused)
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



    private void PauseListener(bool isPaused)
    {
        Debug.Log("Pause State Changed!");
    }
    
    IEnumerator ReEnablePause(float duration)
    {
        yield return new WaitForSeconds(duration);
        _isPausable = true;
    }
}
