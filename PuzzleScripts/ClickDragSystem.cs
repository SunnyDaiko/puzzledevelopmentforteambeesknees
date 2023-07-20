using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragSystem : MonoBehaviour
/*{
    public GameObject correctForm;
    private bool moving;
    private Vector3 mousePos;

    private float startPosX;
    private float startPosY;
    private float startPosZ;

    void Start()
    {
        
    }

    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.GameObject.transorm.localPostion = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, mousePos.z - startPosZ, this.GameObject.transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            startPosZ = mousePos.z - this.transform.localPosition.z;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
    }
}
