using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    private float speed = 4f;
    void Update()
    {
        float zPos = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * zPos * Time.deltaTime);
        GameObject.Find("Menu").transform.Translate(Vector3.up * speed * zPos * Time.deltaTime);
        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = new Quaternion(0f, -5f, 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = new Quaternion(0f, 5f, 0f, 0f);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }*/
        if (Input.GetKeyDown(KeyCode.Escape) && transform.rotation.y==0)
        {
            transform.rotation = new Quaternion(0f, -5f, 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && transform.rotation.y != 0)
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        float Zoom = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.up * 120f * Zoom * Time.deltaTime );
        GameObject.Find("Menu").transform.Translate(Vector3.up * 120f * Zoom * Time.deltaTime);
  
    }
}
