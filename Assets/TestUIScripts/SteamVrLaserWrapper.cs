 using UnityEngine;
 using UnityEngine.EventSystems;
 using Valve.VR.Extras;
 using UnityEngine.UI;
 using System.Collections;

 public class SteamVrLaserWrapper : MonoBehaviour
 { 
    
    
    
    public SteamVR_LaserPointer LeftlaserPointer;
    public SteamVR_LaserPointer RightlaserPointer;
    Slider slider;
    Button button;

   void Start(){

   }
    void Awake()
    { 
       LeftlaserPointer.PointerOut += PointerOutside;
        LeftlaserPointer.PointerClick += PointerClick;
        LeftlaserPointer.PointerIn += PointerInside; 
        
        RightlaserPointer.PointerOut += PointerOutside;
        RightlaserPointer.PointerClick += PointerClick;
        RightlaserPointer.PointerIn += PointerInside; 

       
       /* laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
        laserPointer.PointerIn += PointerInside;

        */
    }
    

    public void PointerClick(object sender, PointerEventArgs e)
    {   
        var button = e.target.GetComponent<Button>();
        var slider = e.target.GetComponent<Slider>();
        if(button != null)
        {
            button.Select();
        }
        if(slider !=null){
            if(slider.value == 0){
          slider.value=1;
         
          Debug.Log(slider.value);
        }
        else if(slider.value== 1)
        {
             slider.value= 0;
       } 
     }
    }
    

    public void PointerOutside(object sender, PointerEventArgs e)
    {
       
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void PointerInside(object sender, PointerEventArgs e)
    {
          Debug.Log("Button name" + button.name);
    }
    

   

  
 }
  