using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddClick : MonoBehaviour {
    int i = 0;
    private void OnMouseDown()
    {
        if(GameObject.Find("Main Camera").GetComponent<Generator>().Getlenght()!= GameObject.Find("Main Camera").GetComponent<Generator>().Getinst_objsLenght())
        {
            GameObject.Find("Main Camera").GetComponent<Generator>().ADD();
        }else
        {
            GameObject.Find("Main Camera").GetComponent<Generator>().Reset();
        }
        transform.localScale = new Vector3(transform.localScale.x / 2f, transform.localScale.y / 2f, transform.localScale.z / 2f);
        i += 1;
    }
    private void OnMouseUp()
    {
        for (; i != 0; i--)
        {
            transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f);
        }
    }
}
