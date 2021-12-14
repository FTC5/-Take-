using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_obj_click : MonoBehaviour {
    private bool state=false;
    public void OnMouseDown()
    {
        //Debug.Log(state);
        if(GameObject.Find("Wall").GetComponent< Instcheaked >().GetNumobj()!=2)
        {
            if (transform.position.z == 0)
            {
                Debug.Log(transform.position.z);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.9f);
                state = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.9f);
                state = false;
              
            }
        }
        else if (transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.9f);
            state = false;
        }
    }
    public bool GetState()
    {
        return state;
    }
    public void SetState()
    {
        state = false;
    }
    
 }
