using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public GameObject wireObj;
    WireHandler wireHandler;
    GameObject currLine;
    bool mouseDown;

    void Start()
    {
        wireHandler = wireObj.GetComponent<WireHandler>();
        wireHandler.start = null;
        mouseDown = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject ioDevice = getObjectAt(Input.mousePosition, "IODevice");
            if (ioDevice != null)
            {
                currLine = wireHandler.CreateLine(ioDevice, Input.mousePosition);
                mouseDown = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (currLine != null && mouseDown)
            {
                GameObject ioDevice = getObjectAt(Input.mousePosition, "IODevice");
                wireHandler.GetComponent<WireHandler>().UpdateLine(currLine, ioDevice, Input.mousePosition);

            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            if (currLine != null)
            {
                if (currLine.GetComponent<WireHandler>().end == null)
                {
                    Destroy(currLine);
                } else {
                    currLine.GetComponent<WireHandler>().end.GetComponent<InputOutput>().input = currLine.GetComponent<WireHandler>().start;
                }
            }
        }


    }

    public void andClick(){

    }

    public void notClick(){
        
    }

    private GameObject getObjectAt(Vector2 mousePos, string objName)
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.transform.parent.gameObject.name == objName)
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}
