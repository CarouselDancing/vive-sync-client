using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private List<Transform> _points;

    // Start is called before the first frame update
    void Start()
    {
       lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //lineRenderer.positionCount = _points.;
        //for (int i = 0; i < _points.Length; i++);
        //{
        //    _lineRenderer.SetPosition(i, _pointTransforms[i].position);
        //}
    }
}