using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linecontroller : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] private Transform[] _points;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = _points.Length;
        for (int i = 0; i < _points.Length; i++)
        {
            lineRenderer.SetPosition(i, _points[i].position);
        }
    }
}