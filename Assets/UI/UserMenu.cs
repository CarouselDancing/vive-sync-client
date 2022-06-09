using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Carousel.BaselineAgent;


public class UserMenu : MonoBehaviour
{
    RPMUserAvatar _userAvatar;
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
