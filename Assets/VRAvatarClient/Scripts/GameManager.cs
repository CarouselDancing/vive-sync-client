using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR;
using Carousel.BaselineAgent;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GlobalAgentGameState state;
    public GameObject networkClient;
    public GameObject offlineTest;
    VRRigConfig trackerConfig;

    void Start()
    {
        trackerConfig = Camera.main.GetComponent<VRRigConfig>();
        state = (GlobalAgentGameState) GlobalAgentGameState.GetInstance();
        ConfigureRig();

        if (state.config.activateDebugVis)
        {
            GameObject.Instantiate(offlineTest);
        }
        else
        {
            var o = GameObject.Instantiate(networkClient);
            o.AddComponent<AutoconnectClient>();
        }
    }

    void ConfigureRig()
    {
        if (trackerConfig == null)
        {
            return;
        }
        ConfigureTracker(trackerConfig.hipTrackerTarget, state.config.hipTracker);
        ConfigureTracker(trackerConfig.leftFootTarget, state.config.leftFootTracker);
        ConfigureTracker(trackerConfig.rightFootTarget, state.config.rightFootTracker);
    }
    

    public void ConfigureTracker(TrackerTarget tracker, TrackerConfig config)
    {
        /*var ht = trackerConfig.hipTrackerTarget.GetComponent<SteamVR_TrackedObject>();
        var _offset = config.posOffset;
        tracker.offset = new Vector3(_offset[0], _offset[1], _offset[2]);
        var _rotOffset = config.rotOffset;
        tracker.rotationOffset = new Vector3(_rotOffset[0], _rotOffset[1], _rotOffset[2]);
        var t = tracker.GetComponent<SteamVR_TrackedObject>();
        t.SetDeviceIndex(config.deviceID);
        Debug.Log("set device id" + name + ": " + config.deviceID.ToString());
        */    
    }




}
