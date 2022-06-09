using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.Extras;

public enum WristMenuState{
    CLOSED,
    LEFT,
    RIGHT
}

public class WristMenu : MonoBehaviour
{
  WristMenuState state = WristMenuState.CLOSED;
  public SteamVRCanvas wristUI;
  public SteamVR_Action_Boolean menuopen;
  public GameObject leftController, rightController, rightChild, leftChild, parentObject;
  bool initialized = false;
  public Vector3 offset;
  

    
  void Update(){
      if (!initialized) Init();
  }

  public void Init(){
      rightController = transform.Find("RightController").gameObject;
      leftController = transform.Find("LeftController").gameObject;
      rightController.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
      leftController.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
      rightChild = transform.Find("RightController/New Game Object").gameObject;
      rightChild.SetActive(false);
      leftChild = transform.Find("LeftController/New Game Object").gameObject;
      leftChild.SetActive(false);
      initialized = true;
  }

  public void ToggleLeft(){
    if (state == WristMenuState.CLOSED){
      state = WristMenuState.LEFT;
      wristUI.Show();
      wristUI.transform.SetParent(leftController.transform);
      wristUI.transform.localPosition = offset;
      rightController.transform.GetComponent<SteamVR_LaserPointer>().enabled= true;
      rightChild.SetActive(true);
    }else if(state == WristMenuState.LEFT){
      state = WristMenuState.CLOSED;
      wristUI.Hide();
      rightController.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
      rightChild.SetActive(false);
    }
    
  }

  public void ToggleRight(){
    if (state == WristMenuState.CLOSED){
      state = WristMenuState.RIGHT;
      wristUI.Show();
      wristUI.transform.SetParent(rightController.transform);
      wristUI.transform.localPosition = offset;
      leftController.transform.GetComponent<SteamVR_LaserPointer>().enabled= true;
      leftChild.SetActive(true);
    }else if(state == WristMenuState.RIGHT){
      state = WristMenuState.CLOSED;
      wristUI.Hide();
      leftController.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
      leftChild.SetActive(false);
    }
    
  }

}
