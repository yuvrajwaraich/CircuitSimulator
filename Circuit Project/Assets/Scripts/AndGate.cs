using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndGate : MonoBehaviour
{
    public GameObject andGatePrefab;
    GameObject input1;
    GameObject input2;
    GameObject output;
    RectTransform rectTransform;

    float deltaX, deltaY;

    // Start is called before the first frame update
    void Start()
    {
        input1 = transform.Find("IODevice").Find("Input1").gameObject;
        input2 = transform.Find("IODevice").Find("Input2").gameObject;
        output = transform.Find("IODevice").Find("Output").gameObject;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Destroy(gameObject);
        }

        if (input1.GetComponent<InputOutput>().turnedOn && input2.GetComponent<InputOutput>().turnedOn) {
            output.GetComponent<InputOutput>().turnedOn = true;
        } else {
            output.GetComponent<InputOutput>().turnedOn = false;
        }
    }

    private void OnMouseDown(){
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag(){
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + deltaX, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + deltaY);
    }

    public void createGate(){
        Instantiate(andGatePrefab, Vector2.zero, Quaternion.identity);
    }
}
