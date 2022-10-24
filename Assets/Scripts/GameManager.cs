using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Image _pauseScreen;
    
    //The method signature of how the event listeners/subscibers need to have
    public delegate void PauseDelegate();
    
    //The event that is triggered when the p button is pressed
    public event PauseDelegate Pause_State_Changed;
    
    //The variable storing the pause state (True / False)
    private bool _isPaused;
    
    //The getter and setter in one place
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
                Time.timeScale = value ? 0 : 1;
                //Triggering the event
                Pause_State_Changed?.Invoke();
            }
            
        }
    }

    private void Start()
    {
        _pauseScreen = GameObject.Find("Canvas").GetComponent<Image>();
        
        //Subscribing
        //Adding the method PauseListener to listen to Pause_State_Changed
        Pause_State_Changed += PauseListener;
    }
    private void OnDestroy()
    {
        //Unsubscribing
        //Removing the method PauseListener to stop listening to Pause_State_Changed
        Pause_State_Changed -= PauseListener;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Change pause state
            Paused = !Paused;
            //Update the UI
            _pauseScreen.enabled = Paused;
        }  
    }

    //The listener/subscibed method, listening to the event
    private void PauseListener()
    {
        Debug.Log(Paused ? "Game is currently Paused" : "Game is currently active");
    }
    
}
