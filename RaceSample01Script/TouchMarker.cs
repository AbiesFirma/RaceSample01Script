using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMarker : MonoBehaviour
{    
    bool onFlick;

    LineRenderer lineRenderer;
    [SerializeField] Material lineMaterial;

    [SerializeField] GameObject startMarker;
    [SerializeField] GameObject currentMarker;

    void Start()
    {
        startMarker.SetActive(false);
        currentMarker.SetActive(false);

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMarker.SetActive(true);
            currentMarker.SetActive(true);

            Vector3 startPosSc = Input.mousePosition;
            startPosSc.z = 10.0f;
            Vector3 startMarkerPos = Camera.main.ScreenToWorldPoint(startPosSc);
            startMarker.transform.position = startMarkerPos;
            currentMarker.transform.position = startMarkerPos;
            
            onFlick = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosSc = Input.mousePosition;
            currentPosSc.z = 10.0f;
            Vector3 currentMarkerPos = Camera.main.ScreenToWorldPoint(currentPosSc);
            currentMarker.transform.position = currentMarkerPos;

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, startMarker.transform.position);
            lineRenderer.SetPosition(1, currentMarker.transform.position);

            lineRenderer.material = lineMaterial;
            lineRenderer.startWidth = 0.2f;
            lineRenderer.endWidth = 0.6f;

        }
        if (Input.GetMouseButtonUp(0))
        {
            startMarker.SetActive(false);
            currentMarker.SetActive(false);

            lineRenderer.enabled = false;

            onFlick = false;
        }
                
    }
}
