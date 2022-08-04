using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public enum WristMenuState{
    CLOSED,
    LEFT,
    RIGHT
}

public class WristMenu : MonoBehaviour
{
  WristMenuState state = WristMenuState.CLOSED;
  public Transform canvasParent;
  public Canvas canvas;
  //public Transform leftController, rightController;
  public Transform XRrig;
  public Vector3 offset;
  public bool active = true;
  public static WristMenu Instance;

    void Awake(){
        
        if(Instance == null){
            Instance = this;
        }else{
            GameObject.DestroyImmediate(gameObject); //singleton monobehavior
        }
    }


  public void ToggleLeft(){
    if(!active)return;
    if (state == WristMenuState.CLOSED){
      state = WristMenuState.LEFT;
      Show();
      canvasParent.SetParent(XRrig.transform);
      canvasParent.localPosition = offset;
    }else if(state == WristMenuState.LEFT){
      state = WristMenuState.CLOSED;
      Hide();
    }
    
  }

  public void ToggleRight(){
    if(!active)return;
    if (state == WristMenuState.CLOSED){
      state = WristMenuState.RIGHT;
      Show();
      canvasParent.SetParent(XRrig.transform);
      canvasParent.localPosition = offset;
    }else if(state == WristMenuState.RIGHT){
      state = WristMenuState.CLOSED;
      Hide();
    }
    
  }

  
    public void Show(){
        canvas.enabled = true;
    }

    public void Hide(){
        canvas.enabled = false;

    }

    
    public void Activate(){
        active = true;
    }   
    
    public void Deactivate(){
        Hide();
        active = false;
    }

}
