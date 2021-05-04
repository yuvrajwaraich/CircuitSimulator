using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOutput : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 position;
    public GameObject input;
    SpriteRenderer spriteRenderer;

    public bool turnedOn;
    void Start()
    {
        turnedOn = false;
        input = null;
        spriteRenderer = GetComponent<SpriteRenderer>();
        position = transform.position;
    }

    void Update()
    {
        if (turnedOn)
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
        }
        else
        {
            spriteRenderer.color = new Color(0.1320755f, 0.1320755f, 0.1320755f, 1f);
        }
    }

    private void OnMouseUp()
    {
        GameObject ioDevice = getIODevice(Input.mousePosition);
        if (ioDevice != null && ioDevice.GetComponent<InputOutput>() != null &&
                ioDevice.GetComponent<InputOutput>().position == gameObject.GetComponent<InputOutput>().position && input == null)
        {
            turnedOn = !turnedOn;
        }


    }

    private GameObject getIODevice(Vector2 mousePos)
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.transform.parent.gameObject.name == "IODevice")
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}
