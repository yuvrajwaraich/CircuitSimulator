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
    public bool connected;

    // Update is called once per frame
    void Update()
    {
        if (start != null && start.GetComponent<InputOutput>() != null)
        {
            turnedOn = start.GetComponent<InputOutput>().turnedOn;
        }

        if (connected)
        {
            end.GetComponent<InputOutput>().turnedOn = turnedOn;
            lineRend.SetPosition(1, end.transform.position);
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
        currLineLineRend.SetPosition(0, ioDevice.transform.position);
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
            if (lineEnd != null && !(lineEnd.GetComponent<InputOutput>().connected) && lineEnd.transform.position != currStart.transform.position)
            {
                currLineRend.SetPosition(1, lineEnd.transform.position);
                line.GetComponent<WireHandler>().end = lineEnd;
            }
            else
            {
                currLineRend.SetPosition(1, Camera.main.ScreenToWorldPoint(mousePos));
            }
        }
    }
}
