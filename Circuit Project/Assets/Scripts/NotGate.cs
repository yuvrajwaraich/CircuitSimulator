using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : MonoBehaviour
{
    public GameObject notGatePrefab;
    GameObject input;
    GameObject output;

    float deltaX, deltaY;

    // Start is called before the first frame update
    void Start()
    {
        input = transform.Find("IODevice").Find("Input").gameObject;
        output = transform.Find("IODevice").Find("Output").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }

        if (input.GetComponent<InputOutput>().connected)
        {
            output.GetComponent<InputOutput>().turnedOn = !(input.GetComponent<InputOutput>().turnedOn);
        }

    }

    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + deltaX, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + deltaY);
    }

    public void createGate()
    {
        Instantiate(notGatePrefab, Vector2.zero, Quaternion.identity);
    }
}
