//https://forum.unity.com/threads/any-example-of-the-new-2019-1-xr-input-system.629824/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.InputSystem;
 
 
public class XRMultiInputActionController : MonoBehaviour
{


    public List<InputActionReference> inputActions;


    [Tooltip("Event when the button starts being pressed")]
    public UnityEvent OnPress;

    [Tooltip("Event when the button is released")]
    public UnityEvent OnRelease;

    // to check whether it's being pressed
    public bool IsPressed { get; private set; }


    void Update()
    {  
        foreach(var a in inputActions){
            if (a.action.phase == InputActionPhase.Performed)
            {
                    // if start pressing, trigger event
                if (!IsPressed)
                {
                    IsPressed = true;
                    OnPress.Invoke();
                    return;
                }
            }
        }
        if (IsPressed) {
            IsPressed = false;
            OnRelease.Invoke();
        }


    }

}
