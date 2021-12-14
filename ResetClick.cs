using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetClick : MonoBehaviour {
    int i = 0;
    private void OnMouseDown()
    {
        GameObject.Find("Main Camera").GetComponent<Generator>().ResetGame();
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
