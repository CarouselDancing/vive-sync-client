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

public class WristMenu : UserMenuCanvas
{
  WristMenuState state = WristMenuState.CLOSED;
  public Transform canvasParent;
  public Transform leftController, rightController;
  public Vector3 offset;

  public void ToggleLeft(){
    if(!active)return;
    if (state == WristMenuState.CLOSED){
      state = WristMenuState.LEFT;
      Show();
      canvasParent.SetParent(leftController.transform);
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
      canvasParent.SetParent(rightController.transform);
      canvasParent.localPosition = offset;
    }else if(state == WristMenuState.RIGHT){
      state = WristMenuState.CLOSED;
      Hide();
    }
    
  }

  


}
