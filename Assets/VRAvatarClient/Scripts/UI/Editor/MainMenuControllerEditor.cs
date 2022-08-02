using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Carousel{

namespace BaselineAgent{

[CustomEditor(typeof(MainMenuController))]
public class MainMenuControllerEditor : Editor

{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MainMenuController c = (MainMenuController)target;
    
        if (GUILayout.Button("Join"))
        {

           c.ShowServerList();
        }
		if (GUILayout.Button("Back"))
        {

           c.ShowMain();
        }
    }
}
}
}