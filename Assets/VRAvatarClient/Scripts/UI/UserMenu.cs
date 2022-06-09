using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Carousel.BaselineAgent;


public class UserMenu : MonoBehaviour
{
   RPMUserAvatar _userAvatar;


   public void Update(){
      if(_userAvatar != null)return;
      var avatars = GameObject.FindObjectsOfTypeAll(typeof(RPMUserAvatar));
      foreach(RPMUserAvatar a in avatars){
          if( a!= null && a.initiated && a.IsOwner) Register(a);
      }  
   }

   public void Register(RPMUserAvatar userAvatar){
      _userAvatar = userAvatar;
   }

   public void SpawnAgent(){
       Debug.Log("spawn agent");
       _userAvatar?.SpawnAgent();
   } 

   public void ExitGame(){
         Application.Quit();
   }
}
