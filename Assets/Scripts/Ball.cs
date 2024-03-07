using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 2.5f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(0, 0, -2.5f);
        }
    }
}
