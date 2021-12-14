using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instcheaked : MonoBehaviour {

    // Use this for initialization
    public short numobj=0;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(numobj);
        if (numobj < 2 || numobj>=0)
        {
            numobj += 1;
            if (numobj == 2)
            {
                GameObject.Find("Main Camera").GetComponent<Generator>().Search();
            }
        }
        else if (numobj > 2)
        {
            Debug.Log("Error number of instate object set 0");
            other.GetComponent<Game_obj_click>().OnMouseDown();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(numobj>0)
        {
            numobj -= 1;
        }
    }
    public short GetNumobj()
    {
        return numobj;
    }
    public void SetNumobj(short numobj)
    {
        this.numobj = numobj;
    }
}
