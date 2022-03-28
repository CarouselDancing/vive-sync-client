using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientToPlayer : MonoBehaviour
{
    Transform cameraT;
    // Start is called before the first frame update
    void Start()
    {
        cameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.position - cameraT.position;
        transform.rotation = Quaternion.LookRotation(forward.normalized);
    }
}
