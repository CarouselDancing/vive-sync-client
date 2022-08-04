using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCamera : MonoBehaviour
{
 
public Canvas canvas;

 public Camera camera;

 

 
    void Start ()
    {
       camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
       canvas.renderMode = RenderMode.ScreenSpaceCamera;
       canvas.planeDistance = 10;
       canvas.worldCamera = camera;
    }
}