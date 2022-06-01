using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.Extras;
public class wristmenu : MonoBehaviour
{
   public bool activeWristUI= false;
   public GameObject wristUI;
   public SteamVR_Action_Boolean menuopen;
   GameObject Leftcontroller,rightchild, leftchild, Rightcontroller, parentObject;
  
  bool isDone = false;
  
  
    
    
    void Start()
  {  
        parentObject = GameObject.Find("XRRig");
  //For loop to find the child // 
  for(int i = 0; i < parentObject.transform.childCount; i++)
  {
    Rightcontroller = parentObject.transform.Find("RightController").gameObject;
    Leftcontroller = parentObject.transform.Find("LeftController").gameObject;
  }
}
 

 
void Update(){
     
         LefthandController();
        
         RighthandController();







        /// It will excecute only one time and it is for to disactivate the pointer Lasers//
        if (!isDone) {
        Rightcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
        Leftcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
        rightchild = parentObject.transform.Find("RightController/New Game Object").gameObject;
        rightchild.SetActive(false);
        leftchild = parentObject.transform.Find("LeftController/New Game Object").gameObject;
        leftchild.SetActive(false);

        isDone = true;
    }


      }
    // Show the Canvas/Menu?//
   public void DisplayWristUI(){
        if(activeWristUI){
           wristUI.SetActive(false);
           activeWristUI = false;
           
           leftchild.SetActive(false);
           Leftcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
         
           
           rightchild.SetActive(false);
           Rightcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;

        }
        else if(!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI= true;
            

        }
    }


    public void LefthandController(){
        if (SteamVR_Actions._default.menuopen.GetStateDown(SteamVR_Input_Sources.LeftHand)){  // Action trigger when press the button//
            
             //This one line to make canvas child to Left hand//
            wristUI.transform.SetParent(Rightcontroller.transform);
            
            Leftcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= true;
            
            DisplayWristUI();
            
            leftchild = parentObject.transform.Find("LeftController/New Game Object").gameObject;
            
            if(leftchild.activeInHierarchy==true && activeWristUI== true ){
            leftchild.SetActive(false);
            Leftcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
            
            }
            else if(activeWristUI== false && leftchild.activeInHierarchy==false){
            leftchild.SetActive(false);
            Leftcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
            
            }
            else if(leftchild.activeInHierarchy ==true){
            leftchild.SetActive(false);
            Leftcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
            }
            else
            {
               leftchild.SetActive(true);
            Leftcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= true;
           
            }
        } 
    } 
    
   
   public void RighthandController(){
        if (SteamVR_Actions._default.menuopen.GetStateDown(SteamVR_Input_Sources.RightHand)){    // Action trigger when press the button//
             //This one line to make canvas child to Right hand//
              wristUI.transform.SetParent(Leftcontroller.transform);
             
             
              Rightcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= true;
             
              DisplayWristUI();
           
  
            if(rightchild.activeInHierarchy ==true && activeWristUI== true){
            rightchild.SetActive(false);
            Rightcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
            }
            else if(activeWristUI==false && rightchild.activeInHierarchy==false)
            {
            rightchild.SetActive(false);
            Rightcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
           
           }
           else if(rightchild.activeInHierarchy ==true){
            rightchild.SetActive(false);
            Rightcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled= false;
            }
            else{
             rightchild.SetActive(true);
            Rightcontroller.transform.GetComponent<SteamVR_LaserPointer>().enabled=true;
            }
           
            }
       

   }
}
