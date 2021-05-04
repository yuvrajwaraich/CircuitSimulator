using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireHandler : MonoBehaviour
{

    // List<Wire> wires;
    public GameObject linePrefab;
    public GameObject currLine;
    public LineRenderer lineRend;

    public GameObject start;
    public GameObject end;
    public bool turnedOn;

    // Update is called once per frame
    void Update()
    {
        if (start != null && start.GetComponent<InputOutput>() != null)
        {
            turnedOn = start.GetComponent<InputOutput>().turnedOn;
        }

        if (end != null && end.GetComponent<InputOutput>() != null)
        {
            end.GetComponent<InputOutput>().turnedOn = turnedOn;
        }

        if (lineRend != null)
        {
            if (!turnedOn)
            {
                Color color = new Color(0.1320755f, 0.1320755f, 0.1320755f, 1f);
                lineRend.startColor = color;
                lineRend.endColor = color;
            }
            else if (turnedOn)
            {
                Color color = new Color(1, 0, 0, 1f);
                lineRend.startColor = color;
                lineRend.endColor = color;
            }

        }
    }

    public GameObject CreateLine(GameObject ioDevice, Vector2 mousePos) // creates a new wireHandler, which is an actual wire
    {
        currLine = Instantiate(linePrefab, Vector2.zero, Quaternion.identity);
        currLine.GetComponent<WireHandler>().start = ioDevice;
        currLine.GetComponent<WireHandler>().end = null;
        LineRenderer currLineLineRend = currLine.GetComponent<LineRenderer>();
        currLine.GetComponent<WireHandler>().lineRend = currLineLineRend;
        currLineLineRend.SetPosition(0, ioDevice.GetComponent<InputOutput>().position);
        currLineLineRend.SetPosition(1, Camera.main.ScreenToWorldPoint(mousePos));
        return currLine;
    }

    public void UpdateLine(GameObject line, GameObject lineEnd, Vector2 mousePos)
    {
        line.GetComponent<WireHandler>().end = null;
        LineRenderer currLineRend = line.GetComponent<LineRenderer>();
        if (currLineRend != null)
        {
            GameObject currStart = line.GetComponent<WireHandler>().start;
            if (lineEnd != null && lineEnd.GetComponent<InputOutput>().position != currStart.GetComponent<InputOutput>().position)
            {
                currLineRend.SetPosition(1, lineEnd.GetComponent<InputOutput>().position);
                line.GetComponent<WireHandler>().end = lineEnd;
            }
            else
            {
                currLineRend.SetPosition(1, Camera.main.ScreenToWorldPoint(mousePos));
            }
        }
    }
}
