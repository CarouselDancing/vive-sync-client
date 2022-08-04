using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvasKeyboard : MonoBehaviour
{
    GameObject keyboardObject;
    CanvasKeyboard keyboard;
    
    public void Start(){
        keyboardObject =  WristMenu.Instance.canvasKeyboard;
    }
    
    public void Open(){
        keyboardObject.SetActive(true);
        keyboard = keyboardObject.GetComponentInChildren<CanvasKeyboard>();
        keyboard.inputObject = gameObject;
    }
    
    public void Close(){
        keyboard = keyboardObject.GetComponentInChildren<CanvasKeyboard>();
        keyboardObject.SetActive(false);
    }
}
