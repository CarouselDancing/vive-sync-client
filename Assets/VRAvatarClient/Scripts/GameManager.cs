using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GlobalGameState state;
    public GameObject networkClient;
    public GameObject offlineTest;
    
    void Start()
    {
        state = GlobalGameState.GetInstance();

        if (state.config.activateDebugVis)
        {
            GameObject.Instantiate(offlineTest);
        }
        else
        {
            GameObject.Instantiate(networkClient);
        }
    }

    

}
