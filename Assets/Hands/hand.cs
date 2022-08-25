using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

namespace Carousel{
  
public class hand : MonoBehaviour
{
  public ActionBasedController[] controllerArray;

   ActionBasedController leftcontroller, rightcontroller;

   public Handanimation handanimation;

   void Awake(){
      controllerArray = ActionBasedController.FindObjectsOfType<ActionBasedController>();
   }
  void Start()
   {
    rightcontroller = controllerArray[0];
     leftcontroller = controllerArray[1];
   }
    
   void Update()
    {
     var player = MirrorGameManager.Instance.player;
      if (player != null){
      handanimation = player.handanimation;
       if(handanimation != null){
          handanimation.SetLeftGrip(leftcontroller.selectActionValue.action.ReadValue<float>());
          handanimation.SetRightGrip(rightcontroller.selectActionValue.action.ReadValue<float>());
          }
        }
      }
   }
}
    


