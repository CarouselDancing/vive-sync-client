using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Carousel.BaselineAgent;


public class DeviceVisManager : MonoBehaviour
{

    public GameObject deviceVisPrefab;
    // Start is called before the first frame update
    void Start()
    {
        bool activate = GlobalAgentGameState.GetInstance().config.activateDebugVis;
        if (!activate) return;
        for (int i = 1; i< 17; i++)
        {
            GenerateDeviceVis(i);
        }
    }
    void GenerateDeviceVis(int deviceID)
    {
        var o = GameObject.Instantiate(deviceVisPrefab, transform);
        o.name = "Device: " + deviceID.ToString();
        //var t = o.GetComponent<SteamVR_TrackedObject>();
       // t.SetDeviceIndex(deviceID);
        var text = o.GetComponentInChildren<Text>();
        text.text = o.name;
    }
}
