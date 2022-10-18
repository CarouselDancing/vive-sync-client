using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserMenuCanvas : MonoBehaviour
{
 
  public Canvas canvas;
  public static UserMenuCanvas Instance;
  public GameObject canvasKeyboard;
  public bool active = true;
  public GameObject agentCanvas;
  public GameObject OtherplayerCanvas;
  public GameObject AvatarCanvas;
  public GameObject GeneralCanvas;
  public Canvas thirdpersonCanvas;
  public Camera thirdpersonCam;


    void Awake(){
      
      if(Instance == null){
          Instance = this;
      }else{
          GameObject.DestroyImmediate(gameObject); //singleton monobehavior
      }
  }  
   
      public void Toggle(){
        if(!active)return;
        if (!canvas.enabled){
            Show();
        }else{
            Hide();
        }
    }
    
    public void Show(){
        canvas.enabled = true;
    }

    public void Hide(){
        canvas.enabled = false;
        agentCanvas.SetActive(false);
        OtherplayerCanvas.SetActive(false);
        AvatarCanvas.SetActive(false);
        GeneralCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Activate(){
        active = true;
    }   
    
    public void Deactivate(){
        Hide();
        active = false;
    }
    public void ShowThirdCam(){
        if(!thirdpersonCanvas.enabled){
        thirdpersonCanvas.enabled = true;
        thirdpersonCam.enabled= true;}
        else{thirdpersonCanvas.enabled = false;
        thirdpersonCam.enabled = false;
           }
        }

    public void agentCanvasToggle(){
            if(!agentCanvas.active){
            agentCanvas.SetActive(true);
            OtherplayerCanvas.SetActive(false);
            AvatarCanvas.SetActive(false);
            GeneralCanvas.SetActive(false);
        }else
        {
         agentCanvas.SetActive(false);
         EventSystem.current.SetSelectedGameObject(null);
        }
        }
    public void otherplayerCanvasToggle(){
        if(!OtherplayerCanvas.active){
            agentCanvas.SetActive(true);
            OtherplayerCanvas.SetActive(true);
            AvatarCanvas.SetActive(false);
            GeneralCanvas.SetActive(false);
        }
        else
        {
        OtherplayerCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        }
        }
    public void AvatarCanvasToggle(){
        if(!AvatarCanvas.active){
            agentCanvas.SetActive(false);
            OtherplayerCanvas.SetActive(false);
            AvatarCanvas.SetActive(true);
            GeneralCanvas.SetActive(false);
        }
        else
        {
        AvatarCanvas.SetActive(false); 
        EventSystem.current.SetSelectedGameObject(null);
        }
        }
    public void generalCanvasToggle(){
        if(!GeneralCanvas.active){
             agentCanvas.SetActive(true);
            OtherplayerCanvas.SetActive(false);
            AvatarCanvas.SetActive(false);
            GeneralCanvas.SetActive(true);
        }
        else
        {
        GeneralCanvas.SetActive(false); 
        EventSystem.current.SetSelectedGameObject(null);
        }
    }  
} 
