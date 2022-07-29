using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class HoverobjectList : MonoBehaviour
{
   public GameObject g;
   public Selectable_Asset selectable_Asset;
   
   void Start(){
    
   selectable_Asset = g.GetComponent<Selectable_Asset>();  
    
  
   }
   public void store(){
   
   selectable_Asset.storelist(gameObject);
    
   }

   public void selectingObject(){
      Debug.Log(gameObject.name);
   }
}


    
    
