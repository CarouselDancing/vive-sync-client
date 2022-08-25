using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Carousel{

namespace BaselineAgent{

[CustomEditor(typeof(XRLocomotionController))]
public class XRLocomotionControllerEditor : Editor

{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        XRLocomotionController c = (XRLocomotionController)target;
    
		if (GUILayout.Button("MoveToNearestAgent"))
        {

           c.MoveToNearestAgent();
        }
    }
}
}
}