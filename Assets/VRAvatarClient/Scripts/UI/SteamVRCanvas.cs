using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.Extras;
using UnityEngine.UI;




 public class SteamVRCanvas : MonoBehaviour
 { 
    
    public Canvas canvas;
    float lockRotation, lockpositiony;
    RectTransform transf;
    public List<SteamVR_LaserPointer> laserPointers;
    public Button currentButton;


    void Start()
    {
        canvas = GetComponent<Canvas>();
        transf = GetComponent<RectTransform>();
        lockRotation = 0.0f;
        foreach(var laserPointer in laserPointers){
            laserPointer.PointerOut += PointerOutside;
            laserPointer.PointerClick += PointerClick;
            laserPointer.PointerIn += PointerInside; 
        }
    }

    public void Show(){
        
        canvas = GetComponent<Canvas>();
        canvas.enabled = true;
        EventSystem.current.SetSelectedGameObject(null);
        DeselectButton(currentButton);
    }

    public void Hide(){
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        EventSystem.current.SetSelectedGameObject(null);
        DeselectButton(currentButton);

    }
    
    void Update()
    {
        //transf.rotation = Quaternion.Euler (lockRotation, transform.eulerAngles.y, lockRotation);
        //transf.localPosition = new Vector3(transform.localPosition.x, 0f ,1f);
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {   
        var button = e.target.GetComponent<Button>();
        var slider = e.target.GetComponent<Slider>();
        Debug.Log("click");
        if(button != null)
        {
            Debug.Log("Button name" + button.name);
            //button.onClick.Invoke();
            PressButton(button);
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
         var b = e.target.GetComponent<Button>();
         if(b != null){
            DeselectButton(b);
            currentButton = null;
          }
    }
    public void PointerInside(object sender, PointerEventArgs e)
    {   
          currentButton = e.target.GetComponent<Button>();
          if(currentButton != null){
              currentButton.Select();
          }
    }
    void PressButton(Button b){
         if(b != null){

            var go = b.gameObject;
            var ped = new PointerEventData(EventSystem.current);
            //ExecuteEvents.Execute(go, ped, ExecuteEvents.pointerEnterHandler);
            // ExecuteEvents.Execute(go, ped, ExecuteEvents.submitHandler);
            ExecuteEvents.Execute(go, ped, ExecuteEvents.pointerClickHandler);
          }
    }
    void DeselectButton(Button b){
         if(b != null){
            var go = b.gameObject;
            var ped = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(go, ped, ExecuteEvents.deselectHandler);
          }
    }
   

  
 }
  