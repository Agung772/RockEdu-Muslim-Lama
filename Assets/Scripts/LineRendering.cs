using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendering : MonoBehaviour
{
    public LineRenderer lineRenderer;
    Vector3 mousePos, startMousePos;
    Vector3 startMousePosition;

    private void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, 0));


    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition - GetMousePos();

        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition - startMousePos);
            lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0));
            print(startMousePosition);
        }
    }
    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
}
