using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField] float dragSpeed = 2;
    private Vector3 dragOrigin;
    public Vector3 delta;
    private Vector3 startPos;
    [SerializeField] int minX = 8;
 
 
    void Start()
    {
        startPos = this.transform.position;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }
 
        if (Input.GetMouseButton(0))
        {
            delta = dragOrigin - Input.mousePosition;

            Vector3 pos = Camera.main.ScreenToViewportPoint(delta);
            Vector3 move = new Vector3 (0, pos.y * dragSpeed, 0);
            transform.Translate(move, Space.World);

            dragOrigin = Input.mousePosition;

            if (this.transform.position.y < startPos.y){
                this.transform.position = startPos;
            }
        }
    }
}
